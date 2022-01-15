using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HuffmanArchiverForms
{

	class Huffman
	{
		public void CompressFile(string fileName, string archivedFileName)
		{
			byte[] data = File.ReadAllBytes(fileName);
			byte[] arch = CompressBytes(data);
			File.WriteAllBytes(archivedFileName, arch);
		}
		private byte[] CompressBytes(byte[] data)
		{
			int[] freqs = CalculateFreq(data);
			byte[] header = CreateHeader(data.Length, freqs);
			Node root = CreateHuffmanTree(freqs);
			string[] codes = CreateHuffmanCodes(root);
			byte[] bits = Compress(data, codes);
			return header.Concat(bits).ToArray();
		}
		private byte[] CreateHeader(int dataLength, int[] freqs)
		{
			List<byte> header = new List<byte>();
			header.Add((byte)(dataLength & 255)); // помещаем в 4 байта, получается как раз для типа int
			header.Add((byte)((dataLength >> 8) & 255));
			header.Add((byte)((dataLength >> 16) & 255));
			header.Add((byte)((dataLength >> 24) & 255));
			for (int i = 0; i < 256; i++)
				header.Add((byte)freqs[i]);

			return header.ToArray();
		}

		private byte[] Compress(byte[] data, string[] codes)
		{
			List<byte> bits = new List<byte>();
			byte sum = 0;
			byte bit = 1;
			foreach (byte symbol in data)
				foreach (char c in codes[symbol])
				{
					if (c == '1')
						sum |= bit; // операция дизъюнкции

					if (bit < 128)
						bit <<= 1; // бит сдвинуть на единицу, если забыл смотри в калькулятор
					else
					{
						bits.Add(sum);
						sum = 0;
						bit = 1;
					}
				}
			if (bit > 1)
				bits.Add(sum);
			return bits.ToArray();
		}

		private string[] CreateHuffmanCodes(Node root)
		{
			string[] codes = new string[256];
			Next(root, "");
			return codes;

			void Next(Node node, string code)
			{
				if (node.bit0 == null)
					codes[node.symbol] = code;
				else
				{
					Next(node.bit0, code + "0");
					Next(node.bit1, code + "1");
				}
			}
		}

		private int[] CalculateFreq(byte[] data)
		{
			int[] freqs = new int[256];
			foreach (byte d in data)
				freqs[d]++;
			NormalizeFreqs(ref freqs);
			return freqs;
		}
		private void NormalizeFreqs(ref int[] freqs) // нормализация массива, то есть максимальное значение становится 256, а минимальное - 1
		{
			int max = freqs.Max();
			if (max < 255)
				return;
			for (int i = 0; i < freqs.Length; i++)
				if (freqs[i] > 0)
					freqs[i] = 1 + freqs[i] * 255 / (max + 1); // я в ахуе, таймкод 1:41
		}

		private Node CreateHuffmanTree(int[] freqs)
		{
			PriorityQueue<Node> pq = new PriorityQueue<Node>();
			for (int i = 0; i < 256; i++)
				if (freqs[i] > 0)
					pq.Enqueue(freqs[i], new Node((byte)i, freqs[i]));

			while (pq.Size() > 1)
			{
				Node bit0 = pq.Dequeue();
				Node bit1 = pq.Dequeue();
				int freq = bit0.freq + bit1.freq;
				Node next = new Node(bit0, bit1, freq);
				pq.Enqueue(freq, next);
			}
			return pq.Dequeue();
		}

		public void DecompressFile(string archivedFileName, string dataFilename)
		{
			byte[] arch = File.ReadAllBytes(archivedFileName);
			byte[] data = DecompressBytes(arch);

			File.WriteAllBytes(dataFilename, data);
		}
		private byte[] DecompressBytes(byte[] arch)
		{
			ParseHeader(arch, out int dataLength, out int startIndex, out int[] freqs); // берет архив, и получает длину данных, стартовый индекс и частотный словарь
			Node root = CreateHuffmanTree(freqs);
			byte[] data = Decompress(arch, dataLength, startIndex, root);
			return data;
		}
		private void ParseHeader(byte[] arch,
			out int dataLength,
			out int startIndex,
			out int[] freqs)
		{
			dataLength = arch[0] |
						(arch[1] << 8) |
						(arch[1] << 16) |
						(arch[1] << 24);

			freqs = new int[256];
			for (int i = 0; i < 256; i++)
				freqs[i] = arch[4 + i];

			startIndex = 4 + 256;
		}
		private byte[] Decompress(byte[] arch, int dataLength, int startIndex, Node root)
		{
			int size = 0;
			Node current = root;
			List<byte> data = new List<byte>();
			for (int i = startIndex; i < arch.Length; i++)
				for (int bit = 1; bit <= 128; bit <<= 1)
				{
					bool zero = (arch[i] & bit) == 0;
					if (zero)
						current = current.bit0;
					else
						current = current.bit1;
					if (current.bit0 != null)
						continue;
					if (size++ < dataLength)
						data.Add(current.symbol);
					current = root;
				}
			return data.ToArray();
		}
	}
}

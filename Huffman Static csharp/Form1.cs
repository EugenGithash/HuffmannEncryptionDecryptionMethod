using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using BitReaderWriter;

namespace Huffman_Static_csharp
{
    public partial class Form1 : Form
    {
        
        private static string path;
        private static string text_path = @"C:\Users\plesa\Desktop";
        private static string extension;
        List<bool> decode_char_apparition = new List<bool>();
        private static BitWriter bit_writer;
        private static BitReader bit_reader;
        private static Huffmann huffman_object_code;
        private static Huffmann huffman_object_decode;
        private static uint nr_one_bits_code=0;
        private static uint nr_one_bits_decode = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\plesa\Desktop";
            openFileDialog1.Title = "Load file ";
            openFileDialog1.Filter = "All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                
            }
        }

        public static List<uint> ReadBitesFromFile(int number_of_bits, string path)
        {
            bit_reader = new BitReader(path);
            List<uint> text=new List<uint>();
            long bits_in_file = bit_reader.NumberOfBitsInFile;
            while ( bits_in_file >0)
            {
                if(number_of_bits > bits_in_file)
                {
                    number_of_bits = (int)bits_in_file;
                }
                text.Add(bit_reader.ReadNBits(number_of_bits));
                bits_in_file -= number_of_bits;
            }
            bit_reader.Dispose();
            return text;
        }

        public static void WriteEncodedFile(Node Root, List<uint> text,string path,bool second_write=false)
        {
            string fileName = path + ".hs";
            bit_writer = new BitWriter(fileName);
            int nr_of_bits = 0;
            WriteAntet(second_write);

            foreach (uint symbol in text)
            {
                if (Root.Left == null && Root.Right == null)
                {
                    bit_writer.WriteNBits(1, 1);
                }
                else
                {
                    List<bool> encoded_symbol = Root.GoThroughTree(symbol, new List<bool>());

                    foreach (bool bit in encoded_symbol)
                    {
                        if (bit)
                        {
                            bit_writer.WriteNBits(1, 1);
                        }
                        else
                        {
                            bit_writer.WriteNBits(1, 0);
                        }
                    }
                }
            }


                bit_writer.WriteNBits(7, 127,out nr_one_bits_code,true);

            bit_writer.Dispose();
        }


        private static void WriteAntet(bool second_write)
        {
            if (second_write != true)
            {
                bit_writer.WriteNBits(3, nr_one_bits_code);
                for (uint symbol = 0; symbol < 256; symbol++)
                {
                    if (huffman_object_code.statistic.ContainsKey(symbol))
                    {
                        bit_writer.WriteNBits(1, 1);
                    }
                    else
                    {
                        bit_writer.WriteNBits(1, 0);
                    }
                }
                for (uint i = 0; i < 256; i++)
                {
                    if (huffman_object_code.statistic.ContainsKey(i))
                    {
                        bit_writer.WriteNBits(32, (uint)huffman_object_code.statistic[i]);
                    }
                }
            }
            else
            {
                bit_writer.WriteNBits(3, nr_one_bits_code);
                for (uint symbol = 0; symbol < 256; symbol++)
                {
                    if (huffman_object_code.statistic.ContainsKey(symbol))
                    {
                        bit_writer.WriteNBits(1, 1);
                    }
                    else
                    {
                        bit_writer.WriteNBits(1, 0);
                    }
                }
                for (uint i = 0; i < 256; i++)
                {
                    if (huffman_object_code.statistic.ContainsKey(i))
                    {
                        bit_writer.WriteNBits(32, (uint)huffman_object_code.statistic[i]);
                    }
                }
            }
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            List<uint> text = ReadBitesFromFile(8,path);
            huffman_object_code = new Huffmann();
            Node Root = new Node();
            Root= huffman_object_code.EncodeHuffmann(text);
            WriteEncodedFile(Root,text,path);
            WriteEncodedFile(Root, text,path, true);
            bit_writer.Dispose();
            if (checkBox1.Checked == true)
            {
                foreach (var pereche in huffman_object_code.statistic)
                {
                    string code = "";
                    code += (char)pereche.Key;
                    code += ":";
                    List<bool> encoded_symbol = Root.GoThroughTree(pereche.Key, new List<bool>());

                    foreach (bool bit in encoded_symbol)
                    {                
            
                        if (bit)
                        {
                            code += "1";
                        }
                        else
                        {
                            code += "0";
                        }
                    }
                    textBox2.Text += code + "    ";
                }
            }

        }

        private void btnEncodeText_Click(object sender, EventArgs e)
        {
            huffman_object_code = new Huffmann();
            Node Root = new Node();
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(text_path))
                {
                    foreach (char line in textBox1.Text)
                    {
                        sw.Write(line);
                    }
                    sw.Close();
                }
            }
            List<uint> text = ReadBitesFromFile(8,text_path);
            Root = huffman_object_code.EncodeHuffmann(text);
            WriteEncodedFile(Root, text,text_path);
            WriteEncodedFile(Root, text, text_path,true);
            if (checkBox1.Checked==true)
            {
                foreach (var pereche in huffman_object_code.statistic)
                {
                    string code = "";
                    code += (char)pereche.Key;
                    code += ":";
                    List<bool> encoded_symbol = Root.GoThroughTree(pereche.Key, new List<bool>());

                    foreach (bool bit in encoded_symbol)
                    {
  
                        if (bit)
                        {
                            code += "1";
                        }
                        else
                        {
                            code += "0";
                        }
                    }
                    textBox2.Text += code + "     ";
                }
            }
            bit_writer.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"E:\Cursuri scoala\An4sem1\Codare audio-video";
            openFileDialog1.Title = "Load file ";
            openFileDialog1.Filter = "Huffman files|*.hs;*.sf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                extension = path.Remove(path.Length - 3, 3);
                extension = Path.GetExtension(extension);
            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            Dictionary<uint, int> statistic_temp = new Dictionary<uint, int>();
            huffman_object_decode = new Huffmann();
            decode_char_apparition = new List<bool>();
            Node Root = new Node();
            bit_reader = new BitReader(path);
            nr_one_bits_decode = bit_reader.ReadNBits(3);
            for (int c=0;c<=255;c++)
            {
                uint temp_c = bit_reader.ReadNBits(1);
               if(temp_c==0)
                {
                    decode_char_apparition.Add(false);
                }
               else
                {
                    decode_char_apparition.Add(true);
                }
            }
            int number_of_characters=0;
            for (int c = 0; c <= 255; c++)
            {
                if (decode_char_apparition[c])
                {
                    statistic_temp.Add((uint)c, (int)bit_reader.ReadNBits(32));
                    number_of_characters++;
                }          
            }
            huffman_object_decode.statistic = statistic_temp;
            Root= huffman_object_decode.DecodeHuffmann();

            int number_of_bits = 1;
            long bits_in_file = bit_reader.NumberOfBitsInFile - 256 - number_of_characters*32-nr_one_bits_decode-3;
            uint temp_bit;
            List<uint> chars = new List<uint>();
            Node Root_temp = Root;
            if (Root.Left == null && Root.Right == null)
            {
                while (bits_in_file > 0)
                {
                    if (number_of_bits > bits_in_file)
                    {
                        number_of_bits = (int)bits_in_file;
                    }
                    chars.Add(Root.Character_to_encode);
                    bits_in_file -= number_of_bits;
                }

            }
            else
            {
                while (bits_in_file > 0)
                {
                    temp_bit = bit_reader.ReadNBits(number_of_bits);

                    if (temp_bit == 1)
                    {
                        Root_temp = Root_temp.Right;
                    }
                    else
                    {
                        Root_temp = Root_temp.Left;
                    }

                    if (CheckIfLeaf(Root_temp))
                    {
                        chars.Add(Root_temp.Character_to_encode);
                        Root_temp = Root;
                    }

                    bits_in_file -= number_of_bits;
                }
            }
            bit_reader.Dispose();

            WriteDecodedFile(chars);
        }

        public static void WriteDecodedFile(List<uint> chars)
        {
            DateTime now_date = DateTime.Now;
            string decode_path = path+"." + now_date.Day+"-"+now_date.Month+"-"+now_date.Year+"-"+ now_date.Hour+"-"+now_date.Minute+extension;
            bit_writer = new BitWriter(decode_path);

            foreach(uint character in chars)
            {
                bit_writer.WriteNBits(8, character);
            }
            bit_writer.Dispose();
        }
        public static bool CheckIfLeaf(Node Root)
        { 
            if(Root.Left==null && Root.Right==null)
            {
                return true;
            }
            return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

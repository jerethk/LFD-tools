using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFD_Tools.DFTypes;

public class Pltt
{
    public Pltt()
    {
        this.Colours = new PlttColour[256];
        this.Pad = 0;
    }

    public const string BrfJan = "0 0 0 255 255 255 211 239 255 171 223 255 127 207 255 87 195 255 255 0 0 207 0 0 147 0 0 71 0 0 0 255 0 0 203 0 0 155 0 0 95 0 0 55 0 0 91 255 0 39 243 0 19 191 0 7 143 251 227 99 247 187 55 247 139 15 219 91 15 183 47 7 255 0 255 255 0 255 255 0 255 255 0 255 255 0 255 255 0 255 255 0 255 255 0 255 235 235 235 227 227 227 219 219 219 211 211 211 207 207 207 199 199 199 191 191 191 183 183 183 175 175 175 171 171 171 163 163 163 155 155 155 147 147 147 143 143 143 135 135 135 127 127 127 119 119 119 115 115 115 107 107 107 103 103 103 95 95 95 91 91 91 83 83 83 79 79 79 71 71 71 67 67 67 59 59 59 55 55 55 47 47 47 43 43 43 35 35 35 31 31 31 103 111 135 95 103 123 87 95 115 79 87 107 75 79 99 67 71 87 59 67 79 55 59 71 47 51 63 39 43 51 31 35 43 27 27 35 19 19 27 11 15 15 7 7 7 0 0 0 255 231 179 239 211 155 223 195 135 211 179 119 195 163 99 183 147 83 167 135 71 151 119 55 139 103 43 123 91 31 111 79 23 95 67 15 79 55 11 67 43 7 51 31 0 39 23 0 227 111 15 215 103 11 203 95 11 191 91 7 179 83 7 171 75 7 159 71 7 147 63 7 135 59 0 123 55 0 115 47 0 103 43 0 91 35 0 79 31 0 67 27 0 59 23 0 131 231 103 115 215 87 103 203 71 95 191 59 83 179 47 71 167 35 63 151 27 55 139 15 47 127 11 39 115 0 35 103 0 51 87 7 59 75 7 59 59 11 47 43 11 35 27 11 255 215 203 247 199 183 243 187 167 235 175 151 227 163 135 223 151 119 215 139 107 211 131 95 203 119 79 199 111 67 191 103 55 187 95 43 179 87 35 175 83 23 167 75 15 163 71 7 151 95 0 139 79 0 127 63 0 115 51 0 107 39 0 95 31 0 83 19 0 75 15 0 0 0 255 0 0 227 0 0 203 0 0 179 0 0 151 0 0 127 0 0 103 0 0 79 255 0 0 227 0 0 199 0 0 171 0 0 143 0 0 115 0 0 87 0 0 59 0 0 255 131 0 227 111 0 203 95 0 179 79 0 155 63 0 131 47 0 107 35 0 83 27 0 195 115 71 183 107 63 171 99 59 159 91 55 151 87 51 139 79 47 127 71 39 119 67 35 107 59 31 95 51 27 83 47 23 75 39 19 63 35 15 51 27 11 43 23 11 63 35 19 187 235 255 171 227 251 159 223 251 143 215 247 131 207 243 119 199 243 103 195 239 91 187 239 79 179 235 67 175 235 55 167 231 43 159 231 31 151 227 19 143 227 7 139 223 0 131 223 44 24 0 48 24 0 52 28 0 60 32 0 60 36 0 64 36 0 68 40 4 72 44 4 76 44 4 76 48 4 80 48 4 80 48 8 84 52 8 88 56 8 92 56 12 92 60 12 96 60 12 96 60 16 100 64 16 104 64 16 104 68 20 108 68 20 108 72 20 112 72 24 116 76 28 120 80 28 124 84 32 128 84 36 128 88 36 132 88 36 132 92 40 136 92 40 136 96 44 140 96 44 140 100 48 144 100 48 148 104 52 148 108 52 152 108 56 156 112 60 160 116 64 164 120 68 168 124 72 172 128 76 184 136 80 196 148 88 208 160 96 255 255 255";

    public string? Name { get; set; }
    public byte FirstColour { get; set; }
    public byte LastColour { get; set; }
    public PlttColour[] Colours { get; set; }
    public byte Pad { get; set; }

    public void LoadFromFile(string filename)
    {
        this.Name = Path.GetFileNameWithoutExtension(filename).ToUpperInvariant();

        using (var fileStream = File.Open(filename, FileMode.Open, FileAccess.Read))
        {
            this.LoadFromStream(fileStream);
        }
    }

    public bool LoadFromStream(Stream data)
    {
        var dataSize = data.Length;
        if (dataSize < 3)
        {
            throw new Exception("PLTT appears to be invalid.");
        }

        using var reader = new BinaryReader(data);
        reader.BaseStream.Seek(0, SeekOrigin.Begin);
        this.FirstColour = reader.ReadByte();
        this.LastColour = reader.ReadByte();

        // Validate size of data
        if (dataSize != 3 + 3 * (this.LastColour - this.FirstColour + 1))
        {
            throw new Exception("PLTT appears to be invalid.");
        }

        for (int c = 0; c < 256; c++)
        {
            if (c >= this.FirstColour && c <= this.LastColour)
            {
                this.Colours[c] = new PlttColour()
                {
                    R = reader.ReadByte(),
                    G = reader.ReadByte(),
                    B = reader.ReadByte(),
                };
            }
            else
            {
                this.Colours[c] = new PlttColour();
            }
        }

        return true;
    }

    public void WriteToTextFile(string filename)
    {
        using (var fileWriter = new StreamWriter(filename))
        {
            var output = string.Empty;
            for (int c = 0; c < 256; c++)
            {
                output += $"{this.Colours[c].R} {this.Colours[c].G} {this.Colours[c].B} ";
            }

            fileWriter.WriteLine(output);
        }
    }
}

public struct PlttColour
{
    public PlttColour(byte red, byte green, byte blue)
    {
        this.R = red;
        this.G = green;
        this.B = blue;
    }

    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }
}

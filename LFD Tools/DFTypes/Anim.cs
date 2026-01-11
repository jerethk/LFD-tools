using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFD_Tools.DFTypes;

public class Anim
{
    public Anim()
    {
        this.Delts = new();
    }

    public string? Name { get; set; }
    public Int16 NumDelts { get; set; }
    public List<AnimDelt> Delts { get; set; }

    public void LoadFromFile(string filename)
    {
        this.Name = Path.GetFileNameWithoutExtension(filename).ToUpperInvariant();

        using (var fileStream = File.Open(filename, FileMode.Open, FileAccess.Read))
        {
            this.LoadFromStream(fileStream);
        }
    }

    public void LoadFromStream(Stream data)
    {
        using var reader = new BinaryReader(data);
        this.NumDelts = reader.ReadInt16();
        this.Delts.Clear();

        for (var d = 0; d < this.NumDelts; d++)
        {
            var animDelt = new AnimDelt();
            animDelt.Size = reader.ReadInt32();

            using (var deltData = new MemoryStream(reader.ReadBytes(animDelt.Size)))
            {
                animDelt.Delt.LoadFromStream(deltData);
            }

            this.Delts.Add(animDelt);
        }
    }

    public record AnimDelt
    {
        public AnimDelt()
        {
            this.Delt = new();
        }

        public int Size { get; set; }

        public Delt Delt { get; set; }
    }
}

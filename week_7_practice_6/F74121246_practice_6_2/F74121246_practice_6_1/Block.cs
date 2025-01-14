using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F74121246_practice_6_1
{
    [Serializable]
    public class Block
    {
        public readonly BlockType Type;
        public PictureBox picture;

        public enum BlockType
        {
            Grass, 
            Dust, 
            Stone, 
            Water, 
        }

        public Block(BlockType Type)
        {
            this.Type = Type;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace F74121246_practice_6_1
{   
    [Serializable]
    public class GameData
    {
        public List<SimpleBlock> Blocks { get; set; }
        public Point PlayerLocation { get; set; }
        public int heightCount, widthCount;

        public GameData()
        {
            Blocks = new List<SimpleBlock>();
        }

        public void SaveToXml(string filepath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameData));
            using (var writer = new StreamWriter(filepath))
            {
                serializer.Serialize(writer, this);
            }
        }

        public static GameData LoadFromXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameData));
            using (var reader = new StreamReader(filePath))
            {
                return (GameData)serializer.Deserialize(reader);
            }
        }


        public GameData(Block[,] blocks, Point playerLocation, int heightCount, int widthCount)
        {
            this.heightCount = heightCount; this.widthCount = widthCount;
            this.PlayerLocation = playerLocation;
            Blocks = new List<SimpleBlock>();

            for (int x = 0; x < heightCount; x++)
            {
                for (int y = 0; y < widthCount; y++)
                {
                    if (blocks[x, y] == null)
                    {
                        //Console.Write("null  ");
                        Blocks.Add(null); 
                    }
                    else
                    {
                        switch (blocks[x, y].Type)
                        {
                            case Block.BlockType.Grass:
                                //Console.Write("Grass ");
                                Blocks.Add(new SimpleBlock(SimpleBlock.BlockType.Grass));
                                break;
                            case Block.BlockType.Dust:
                                //Console.Write("Dust  ");
                                Blocks.Add(new SimpleBlock(SimpleBlock.BlockType.Dust));
                                break;
                            case Block.BlockType.Stone:
                                //Console.Write("Stone ");
                                Blocks.Add(new SimpleBlock(SimpleBlock.BlockType.Stone));
                                break;
                            case Block.BlockType.Water:
                                //Console.Write("Water ");
                                Blocks.Add(new SimpleBlock(SimpleBlock.BlockType.Water));
                                break;
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        public Block[,] returnToBlocks()
        {
            Block[,] blocks = new Block[heightCount, widthCount];

            for (int x= 0; x < heightCount; x++)
            {
                for (int y= 0; y < widthCount; y++)
                {
                    int index = x * widthCount + y;
                    if (Blocks[index] == null)
                    {
                        //Console.Write("null  ");
                        blocks[x, y] = null;
                    }
                    else
                    {
                        switch (Blocks[index].type)
                        {
                            case SimpleBlock.BlockType.Grass:
                                //Console.Write("Grass ");
                                blocks[x, y] = new Block(Block.BlockType.Grass);
                                
                                break;
                            case SimpleBlock.BlockType.Dust:
                                //Console.Write("Dust  ");
                                blocks[x, y] = new Block(Block.BlockType.Dust);
                                break;
                            case SimpleBlock.BlockType.Stone:
                                //Console.Write("Stone ");
                                blocks[x, y] = new Block(Block.BlockType.Stone);
                                break;
                            case SimpleBlock.BlockType.Water:
                                //Console.Write("Water ");
                                blocks[x, y] = new Block(Block.BlockType.Water);
                                break;
                        }
                    }
                }
                Console.WriteLine();
            }

            return blocks;
        }
    }

    [Serializable]
    public class SimpleBlock
    {
        public BlockType type;

        SimpleBlock()
        {

        }
        public SimpleBlock(BlockType type)
        {
            this.type = type;
        }

        public enum BlockType
        {
            Grass,
            Dust,
            Stone,
            Water,
        }
    }
}

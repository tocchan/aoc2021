using System.Collections;

namespace AoC2021
{
    //----------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------
    public class IntHeatMap2D : IEnumerable<(ivec2,int)>
    {
        //----------------------------------------------------------------------------------------------
        public IntHeatMap2D()
        {
        }

        public IntHeatMap2D( List<string> lines )
        {
            SetFromTightBlock( lines ); 
        }

        //----------------------------------------------------------------------------------------------
        public void Resize( int width, int height, bool keep = false )
        {
            int[] newData = new int[width * height]; 

            if (keep && (Data != null))
            {
                int copyWidth = Math.Min( width, Width ); 
                int copyHeight = Math.Min( height, Height ); 
                for (int y = 0; y < copyHeight; ++y)
                {
                    for (int x = 0; x < copyWidth; ++x)
                    {
                        int srcIdx = y * Width + x; 
                        int dstIdx = y * width + x; 
                        newData[dstIdx] = Data[srcIdx]; 
                    }
                }
            }

            Width = width; 
            Height = height; 
            Data = newData; 
        }
        public void Resize( ivec2 size, bool keep = false ) => Resize( size.x, size.y, keep ); 

        //----------------------------------------------------------------------------------------------
        public void Copy( IntHeatMap2D src, int dstX, int dstY )
        {
            int width = Math.Min( GetWidth() - dstX, src.GetWidth() ); 
            int height = Math.Min( GetHeight() - dstY, src.GetHeight() ); 

            ivec2 srcPos; 
            ivec2 dstPos; 
            for (int y = 0; y < height; ++y)
            {
                srcPos.y = y; 
                dstPos.y = dstY + y; 

                for (int x = 0; x < width; ++x)
                {
                    srcPos.x = x; 
                    dstPos.x = x + dstX; 

                    int val = src.Get(srcPos); 
                    Set(dstPos, val); 
                }
            }
        }

        //----------------------------------------------------------------------------------------------
        public void SetFromTightBlock( List<string> lines, int boundsValue = int.MaxValue )
        {
            BoundsValue = boundsValue; 
            int width = lines[0].Length; 
            int height = lines.Count; 

            Resize( width, height ); 

            int idx = 0; 
            foreach (string line in lines)
            {
                foreach (char c in line)
                {
                    Data[idx] = c - '0'; 
                    ++idx; 
                }
            }
        }

        //----------------------------------------------------------------------------------------------
        private int GetIndex( int x, int y )
        {
            return y * Width + x; 
        }
        private int GetIndex( ivec2 p ) => GetIndex( p.x, p.y ); 

        //----------------------------------------------------------------------------------------------
        public void Set( int x, int y, int value )
        {
            if ((y >= 0) && (y < Height) && (x >= 0) && (x < Width))
            {
                int idx = GetIndex(x, y); 
                Data[idx] = value;
            }
        }
        public void Set( ivec2 pos, int value ) => Set( pos.x, pos.y, value ); 

        //----------------------------------------------------------------------------------------------
        public int Get( int x, int y )
        {
            if ((y >= 0) && (y < Height) && (x >= 0) && (x < Width))
            {
                int idx = GetIndex(x, y); 
                return Data[idx]; 
            }
            else
            {
                return BoundsValue; 
            }
        }
        public int Get( ivec2 p ) => Get( p.x, p.y ); 

        //----------------------------------------------------------------------------------------------
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------------
        IEnumerator<(ivec2,int)> IEnumerable<(ivec2,int)>.GetEnumerator()
        {
            ivec2 pos; 
            int idx = 0; 
            for (pos.y = 0; pos.y < Height; ++pos.y)
            {
                for (pos.x = 0; pos.x < Width; ++pos.x)
                {
                    yield return (pos, Data[idx]); 
                    ++idx; 
                }
            }
        }

        //----------------------------------------------------------------------------------------------
        public IEnumerable<(ivec2,int)> GetRegionEnumerator( ivec2 minInclusive, ivec2 maxInclusive )
        {
            ivec2 min = ivec2.Max( ivec2.ZERO, minInclusive ); 
            ivec2 max = ivec2.Min( GetSize() - ivec2.ONE, maxInclusive ); 

            ivec2 p; 
            for (p.y = min.y; p.y <= max.y; ++p.y)
            {
                for (p.x = min.x; p.x <= max.x; ++p.x)
                {
                    int val = Data[GetIndex(p)]; // no bounds check needed - I make sure all iterations are in here; 
                    yield return (p, val); 
                }
            }
        }

        //----------------------------------------------------------------------------------------------
        public ivec2 GetSize()
        {
            ivec2 ret; 
            ret.x = Width; 
            ret.y = Height; 
            return ret; 
        }

        //----------------------------------------------------------------------------------------------
        public int GetWidth() => Width; 
        public int GetHeight() => Height; 

        public int this[int x, int y]
        {
            get => Get(x, y);
            set => Set(x, y, value);
        }

        public int this[ivec2 p]
        {
            get => Get(p.x, p.y); 
            set => Set(p.x, p.y, value); 
        }

        //----------------------------------------------------------------------------------------------
        // Runs a function on the map, returning the new value for each cell.
        // Value changes apply at the very end.  
        public void CellStep( Func<ivec2, int, int> func )
        {
            int[] newData = new int[Width * Height]; 

            int idx = 0; 
            ivec2 p; 
            for (p.y = 0; p.y < Height; ++p.y)
            {
                for (p.x = 0; p.x < Width; ++p.x)
                {
                    newData[idx] = func(p, Data[idx]); 
                    ++idx; 
                }
            }

            Data = newData; 
        }

        //----------------------------------------------------------------------------------------------
        public List<ivec2> FindPathDijkstra(ivec2 start, ivec2 end)
        {
            PriorityQueue<ivec2, int> points = new PriorityQueue<ivec2, int>(); 
            ivec2[] prevMap = new ivec2[Width * Height]; 
            int[] costs = new int[Width * Height]; 

            for (int i = 0; i < Width * Height; ++i)
            {
                costs[i] = int.MaxValue; 
            }

            prevMap[ GetIndex(end) ] = end; 
            costs[GetIndex(end)] = 0; 

            ivec2[] dirs =
            {
                ivec2.LEFT, 
                ivec2.RIGHT, 
                ivec2.UP,
                ivec2.DOWN, 
            };

            // Start the algorithm - from the end, so I don't have to reverse it when I finish
            points.Enqueue( end, Get(end) ); 
            while (points.Count > 0)
            {
                ivec2 src = points.Dequeue(); 
                if (src == start)
                {
                    break; 
                }

                int srcIdx = GetIndex(src); 
                int srcCost = costs[srcIdx]; 
                foreach (ivec2 dir in dirs)
                {
                    ivec2 dst = src + dir; 
                    int dstIdx = GetIndex(dst); 
                    int dstCost = Get(dst); 
                    if ((dstCost != BoundsValue) && (costs[dstIdx] == int.MaxValue))
                    {
                        dstCost += srcCost; 
                        costs[dstIdx] = dstCost;
                        prevMap[dstIdx] = src; 

                        points.Enqueue( dst, dstCost ); 
                    }
                }
            }

            // okay, have my path, follow it to the start
            List<ivec2> path = new List<ivec2>(); 

            ivec2 pos = start; 
            path.Add(pos); 

            while (prevMap[GetIndex(pos)] != pos)
            {
                pos = prevMap[GetIndex(pos)]; 
                path.Add(pos); 
            }

            return path; 
        }

        //----------------------------------------------------------------------------------------------
        public int SumValuesAlong( List<ivec2> path )
        {
            int total = 0; 
            foreach (ivec2 pos in path)
            {
                total += Get( pos.x, pos.y ); 
            }

            return total; 
        }

        //----------------------------------------------------------------------------------------------
        private int[] Data = new int[0];  
        private int Width = 0; 
        private int Height = 0; 
        private int BoundsValue = int.MaxValue;
    }
}

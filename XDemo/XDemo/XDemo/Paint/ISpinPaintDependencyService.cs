using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XDemo.Paint
{
    public interface ISpinPaintDependencyService
    {
        Task<bool> SaveBitmap(byte[] bitmapData, string filename);
    }
}

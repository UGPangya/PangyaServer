using PangyaFileCore.IffManager.IffList;
using System.Runtime.CompilerServices;

namespace PangyaFileCore.IffManager
{
    public static class IffMain
    {
        public static IFFFileManager IFFFileManager { get; set; }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Load()
        {
           IFFFileManager = new IFFFileManager();
        }       
    }
}

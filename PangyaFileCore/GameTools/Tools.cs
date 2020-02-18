using System;
using System.IO;
using System.Linq;
using static System.Math;
using System.Runtime.CompilerServices;
using System.Text;
namespace PangyaFileCore.GameTools
{
    public static class Tools
    {
       
        /// <summary>
        /// Compara dados e retorna dados caso true ou false
        /// </summary>
        /// <typeparam name="T">Tipo</typeparam>
        /// <param name="Expression">Exemplo: GameInfo.Password.Leght > 0</param>
        /// <param name="IfTrue">2</param>
        /// <param name="IfFalse">1</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static T IfCompare<T>(bool Expression, T IfTrue, T IfFalse)
        {
            if (Expression)
            {
                return IfTrue;
            }
            return IfFalse;
        }


        public static T IfCompare<T>(bool check, bool Expression, T IfTrue, T IfFalse)
        {
            if (Expression && check)
            {
                return IfTrue;
            }
            return IfFalse;
        }
        
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static uint GetItemGroup(uint TypeID)
        {
            var result = (uint)Round((TypeID & 4227858432) / Pow(2.0, 26.0));

            return result;
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static uint GetCharGroup(uint TypeID)
        {
            var result = (uint)Round((TypeID & 4227858432) / Pow(2.0, 24.0));

            return result;
        }
       

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte GetAuxType(uint ID)
        {
            byte result;

            result = (byte)Round((ID & 0x001F0000) / Pow(2.0, 16.0));

            return result;
        }       
    }
}

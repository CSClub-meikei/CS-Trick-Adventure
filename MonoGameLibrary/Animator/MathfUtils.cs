using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLibrary.Animator
{
    /// <summary>
    /// Math クラスに関する汎用関数を管理するクラス
    /// </summary>
    public static class MathUtils
    {
        /// <summary>
        /// ベジェ曲線における X 座標を返します
        /// </summary>
        /// <remarks>http://opentype.jp/fontguide_doc3.htm</remarks>
        /// <param name="x1">開始点の X 座標</param>
        /// <param name="x2">制御点 1 の X 座標</param>
        /// <param name="x3">制御点 2 の X 座標</param>
        /// <param name="x4">終点の X 座標</param>
        /// <param name="t">重み(0 から 1)</param>
        /// <returns>ベジェ曲線における X 座標</returns>
        public static double BezierCurveX(double x1, double x2, double x3, double x4, double t)
        {
            return Math.Pow(1 - t, 3) * x1 + 3 * Math.Pow(1 - t, 2) * t * x2 + 3 * (1 - t) * Math.Pow(t, 2) * x3 + Math.Pow(t, 3) * x4;
        }

        /// <summary>
        /// ベジェ曲線における Y 座標を返します
        /// </summary>
        /// <remarks>http://opentype.jp/fontguide_doc3.htm</remarks>
        /// <param name="y1">開始点の Y 座標</param>
        /// <param name="y2">制御点 1 の Y 座標</param>
        /// <param name="y3">制御点 2 の Y 座標</param>
        /// <param name="y4">終点の Y 座標</param>
        /// <param name="t">重み(0 から 1)</param>
        /// <returns>ベジェ曲線における Y 座標</returns>
        public static double BezierCurveY(double y1, double y2, double y3, double y4, double t)
        {
            return Math.Pow(1 - t, 3) * y1 + 3 * Math.Pow(1 - t, 2) * t * y2 + 3 * (1 - t) * Math.Pow(t, 2) * y3 + Math.Pow(t, 3) * y4;
        }

        /// <summary>
        /// ベジェ曲線における 2 次元座標を返します
        /// </summary>
        /// <param name="p1">開始点の座標</param>
        /// <param name="p2">制御点 1 の座標</param>
        /// <param name="p3">制御点 2 の座標</param>
        /// <param name="p4">終点の座標</param>
        /// <param name="t">重み(0 から 1)</param>
        /// <returns>B-スプライン曲線における 2 次元座標</returns>
        public static Vector2 BezierCurve(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, double t)
        {
            return new Vector2(
                (float)BezierCurveX(p1.X, p2.X, p3.X, p4.X, t),
                (float)BezierCurveY(p1.Y, p2.Y, p3.Y, p4.Y, t));
        }
    }
}

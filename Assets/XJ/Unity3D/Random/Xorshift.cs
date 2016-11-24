using UnityEngine;

namespace XJ.Unity3D.Random
{
    /// <summary>
    /// Xorshift で乱数を得るためのクラス。
    /// </summary>
    public class Xorshift : XJ.NET.Random.Xorshift
    {
        #region Constructor

        /// <summary>
        /// 新しいインスタンスを初期化します。
        /// </summary>
        public Xorshift()
            : base()
        {
        }

        /// <summary>
        /// 新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="seed">
        /// シード値。
        /// </param>
        public Xorshift(uint seed)
            :base(seed)
        {
        }

        #endregion Constructor

        #region Method

        /// <summary>
        /// 単位円上のランダムな点の座標を取得します。
        /// </summary>
        /// <returns>
        /// 単位円上のランダムな点。
        /// </returns>
        public Vector2 OnUnitCircle()
        {
            float x, y;

            base.OnUnitCircle(out x, out y);

            return new Vector2(x, y);
        }

        /// <summary>
        /// 単位円上のランダムな点の座標を取得します。
        /// </summary>
        /// <returns>
        /// 単位円内のランダムな点。
        /// </returns>
        public Vector2 InsideUnitCircle()
        {
            float x, y;

            base.InsideUnitCircle(out x, out y);

            return new Vector2(x, y);
        }

        /// <summary>
        /// 単位球上のランダムな点の座標を取得します。
        /// </summary>
        /// <returns>
        /// 単位球上のランダムな点。
        /// </returns>
        public Vector3 OnUnitSphere()
        {
            float x, y, z;

            base.OnUnitSphere(out x, out y, out z);

            return new Vector3(x, y, z);
        }

        /// <summary>
        /// 単位球内のランダムな点の座標を取得します。
        /// </summary>
        /// <returns>
        /// 単位球内のランダムな点。
        /// </returns>
        public Vector3 InsideUnitSphere()
        {
            float x, y, z;

            base.InsideUnitSphere(out x, out y, out z);

            return new Vector3(x, y, z);
        }

        /// <summary>
        /// ランダムな Quaternion 型の値を返します。
        /// </summary>
        /// <returns>
        /// ランダムな Quaternion 型の値。
        /// </returns>
        public Quaternion Rotation()
        {
            return new Quaternion(base.Value() * base.Range(0, 2) == 0 ? 1 : -1,
                                  base.Value() * base.Range(0, 2) == 0 ? 1 : -1,
                                  base.Value() * base.Range(0, 2) == 0 ? 1 : -1,
                                  base.Value() * base.Range(0, 2) == 0 ? 1 : -1);
        }

        /// <summary>
        /// ランダムな色を取得します。
        /// </summary>
        /// <param name="hueMin">
        /// 最低色相 [0..1]。
        /// </param>
        /// <param name="hueMax">
        /// 最高色相[0..1]。
        /// </param>
        /// <param name="saturationMin">
        /// 最低彩度[0..1]。
        /// </param>
        /// <param name="saturationMax">
        /// 最高彩度[0..1]。
        /// </param>
        /// <param name="valueMin">
        /// 最小値[0..1]。
        /// </param>
        /// <param name="valueMax">
        /// 最大値[0..1]。
        /// </param>
        /// <param name="alphaMin">
        /// 最低アルファ[0..1]。
        /// </param>
        /// <param name="alphaMax">
        /// 最高アルファ[0..1]。
        /// </param>
        /// <returns>
        /// ランダムな色。
        /// </returns>
        public Color ColorHSV()
        {
            return ColorHSV(0, 1,
                            0, 1,
                            0, 1,
                            1, 1);
        }

        /// <summary>
        /// ランダムな色を取得します。
        /// </summary>
        /// <param name="hueMin">
        /// 最低色相 [0..1]。
        /// </param>
        /// <param name="hueMax">
        /// 最高色相[0..1]。
        /// </param>
        /// <param name="saturationMin">
        /// 最低彩度[0..1]。
        /// </param>
        /// <param name="saturationMax">
        /// 最高彩度[0..1]。
        /// </param>
        /// <param name="valueMin">
        /// 最小値[0..1]。
        /// </param>
        /// <param name="valueMax">
        /// 最大値[0..1]。
        /// </param>
        /// <param name="alphaMin">
        /// 最低アルファ[0..1]。
        /// </param>
        /// <param name="alphaMax">
        /// 最高アルファ[0..1]。
        /// </param>
        /// <returns>
        /// ランダムな色。
        /// </returns>
        public Color ColorHSV(float hueMin, float hueMax)
        {
            return ColorHSV(hueMin, hueMax,
                            0, 1,
                            0, 1,
                            1, 1);
        }

        /// <summary>
        /// ランダムな色を取得します。
        /// </summary>
        /// <param name="hueMin">
        /// 最低色相 [0..1]。
        /// </param>
        /// <param name="hueMax">
        /// 最高色相[0..1]。
        /// </param>
        /// <param name="saturationMin">
        /// 最低彩度[0..1]。
        /// </param>
        /// <param name="saturationMax">
        /// 最高彩度[0..1]。
        /// </param>
        /// <param name="valueMin">
        /// 最小値[0..1]。
        /// </param>
        /// <param name="valueMax">
        /// 最大値[0..1]。
        /// </param>
        /// <param name="alphaMin">
        /// 最低アルファ[0..1]。
        /// </param>
        /// <param name="alphaMax">
        /// 最高アルファ[0..1]。
        /// </param>
        /// <returns>
        /// ランダムな色。
        /// </returns>
        public Color ColorHSV(float hueMin, float hueMax,
                              float saturationMin, float saturationMax)
        {
            return ColorHSV(hueMin, hueMax,
                            saturationMin, saturationMax,
                            0, 1,
                            1, 1);
        }

        /// <summary>
        /// ランダムな色を取得します。
        /// </summary>
        /// <param name="hueMin">
        /// 最低色相 [0..1]。
        /// </param>
        /// <param name="hueMax">
        /// 最高色相[0..1]。
        /// </param>
        /// <param name="saturationMin">
        /// 最低彩度[0..1]。
        /// </param>
        /// <param name="saturationMax">
        /// 最高彩度[0..1]。
        /// </param>
        /// <param name="valueMin">
        /// 最小値[0..1]。
        /// </param>
        /// <param name="valueMax">
        /// 最大値[0..1]。
        /// </param>
        /// <param name="alphaMin">
        /// 最低アルファ[0..1]。
        /// </param>
        /// <param name="alphaMax">
        /// 最高アルファ[0..1]。
        /// </param>
        /// <returns>
        /// ランダムな色。
        /// </returns>
        public Color ColorHSV(float hueMin, float hueMax,
                              float saturationMin, float saturationMax,
                              float valueMin, float valueMax)
        {
            return ColorHSV(hueMin, hueMax,
                            saturationMin, saturationMax,
                            valueMin, valueMax, 
                            1, 1);
        }

        /// <summary>
        /// ランダムな色を取得します。
        /// </summary>
        /// <param name="hueMin">
        /// 最低色相 [0..1]。
        /// </param>
        /// <param name="hueMax">
        /// 最高色相[0..1]。
        /// </param>
        /// <param name="saturationMin">
        /// 最低彩度[0..1]。
        /// </param>
        /// <param name="saturationMax">
        /// 最高彩度[0..1]。
        /// </param>
        /// <param name="valueMin">
        /// 最小値[0..1]。
        /// </param>
        /// <param name="valueMax">
        /// 最大値[0..1]。
        /// </param>
        /// <param name="alphaMin">
        /// 最低アルファ[0..1]。
        /// </param>
        /// <param name="alphaMax">
        /// 最高アルファ[0..1]。
        /// </param>
        /// <returns>
        /// ランダムな色。
        /// </returns>
        public Color ColorHSV(float hueMin, float hueMax,
                              float saturationMin, float saturationMax,
                              float valueMin, float valueMax,
                              float alphaMin, float alphaMax)
        {
            return new Color(base.Range(hueMin, hueMax),
                             base.Range(saturationMin, saturationMax),
                             base.Range(valueMin, valueMax),
                             base.Range(alphaMin, alphaMax));
        }

        #endregion Method
    }
}
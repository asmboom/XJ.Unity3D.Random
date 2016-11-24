namespace XJ.NET.Random
{
    // https://www.jstatsoft.org/article/view/v008i14
    // xor64, xor96, xor128 とありますが、xor128 の実装です。
    // 試行回数が少ないとき、わずかに偏りがあります。

    /// <summary>
    /// Xorshift で乱数を得るためのクラス。
    /// </summary>
    public class Xorshift
    {
        #region Field

        /// <summary>
        /// ラジアンの最小値。0 度を示す。
        /// </summary>
        protected const float RADIAN_MIN = 0;

        /// <summary>
        /// ラジアンの最大値。360 度を示す。
        /// </summary>
        protected const float RADIAN_MAX = 6.283185307179586f;

        /// <summary>
        /// シード X の既定値。
        /// </summary>
        protected const uint SEED_X = 123456789u;

        /// <summary>
        /// シード Y の既定値。
        /// </summary>
        protected const uint SEED_Y = 362436069u;

        /// <summary>
        /// シード Z の既定値。
        /// </summary>
        protected const uint SEED_Z = 521288629u;

        /// <summary>
        /// シード W の既定値。
        /// </summary>
        protected const uint SEED_W = 88675123u;

        private uint x, y, z, w;

        #endregion Field

        #region Constructor

        /// <summary>
        /// 新しいインスタンスを初期化します。
        /// </summary>
        public Xorshift()
        {
            x = Xorshift.SEED_X;
            y = Xorshift.SEED_Y;
            z = Xorshift.SEED_Z;
            w = (uint)System.DateTime.Now.Millisecond;
        }

        /// <summary>
        /// 新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="seed">
        /// シード値。
        /// </param>
        public Xorshift(uint seed)
        {
            x = Xorshift.SEED_X;
            y = Xorshift.SEED_Y;
            z = Xorshift.SEED_Z;
            w = seed;
        }

        #endregion Constructor

        #region Method

        /// <summary>
        /// 0 ~ 2^32-1 の乱数を取得します。
        /// </summary>
        /// <returns>
        /// 0 ~ 2^32-1 の乱数。
        /// </returns>
        public uint ValueNative()
        {
            uint t = x ^ (x << 11);

            x = y;
            y = z;
            z = w;
            w = (w ^ (w >> 19)) ^ (t ^ (t >> 8));

            return w;
        }

        /// <summary>
        /// 0 ~ 1 の乱数を取得します。
        /// </summary>
        /// <returns>
        /// 0 ~ 1 の乱数。
        /// </returns>
        public float Value()
        {
            return (ValueNative() / (float)(uint.MaxValue));
        }

        /// <summary>
        /// 指定した範囲の乱数を取得します。
        /// 引数が int 型のとき、最大値を含みません。
        /// 引数が float 型のとき、最大値を含みます。
        /// </summary>
        /// <param name="min">
        /// 最小値。
        /// </param>
        /// <param name="max">
        /// 最大値。
        /// </param>
        /// <returns>
        /// 指定範囲の乱数。
        /// </returns>
        public int Range(int min, int max)
        {
            uint valueNative = ValueNative();
            return (int)(min + valueNative % (uint)(max - min));
        }

        /// <summary>
        /// 指定した範囲の乱数を取得します。
        /// 引数が int 型のとき、最大値を含みません。
        /// 引数が float 型のとき、最大値を含みます。
        /// </summary>
        /// <param name="min">
        /// 最小値。
        /// </param>
        /// <param name="max">
        /// 最大値。
        /// </param>
        /// <returns>
        /// 指定範囲の乱数。
        /// </returns>
        public float Range(float min, float max)
        {
            return min + (max - min) * Value();
        }

        /// <summary>
        /// 単位円上のランダムな点の座標を取得します。
        /// </summary>
        /// <param name="x">
        /// 単位円上のランダムな点の X 座標。
        /// </param>
        /// <param name="y">
        /// 単位円上のランダムな点の Y 座標。
        /// </param>
        public void OnUnitCircle(out float x, out float y)
        {
            float angle = Range(Xorshift.RADIAN_MIN, Xorshift.RADIAN_MAX);

            x = (float)System.Math.Cos(angle);
            y = (float)System.Math.Sin(angle);
        }

        /// <summary>
        /// 単位円内のランダムな点の座標を取得します。
        /// </summary>
        /// <param name="x">
        /// 単位円内のランダムな点の X 座標。
        /// </param>
        /// <param name="y">
        /// 単位円内のランダムな点の Y 座標。
        /// </param>
        public void InsideUnitCircle(out float x, out float y)
        {
            float angle = Range(Xorshift.RADIAN_MIN, Xorshift.RADIAN_MAX);
            float radius = Value();

            x = (float)System.Math.Cos(angle) * radius;
            y = (float)System.Math.Sin(angle) * radius;
        }

        /// <summary>
        /// 単位球上のランダムな点の座標を取得します。
        /// </summary>
        /// <param name="x">
        /// 単位球上のランダムな点の X 座標。
        /// </param>
        /// <param name="y">
        /// 単位球上のランダムな点の Y 座標。
        /// </param>
        /// <param name="z">
        /// 単位球上のランダムな点の Z 座標。
        /// </param>
        public void OnUnitSphere(out float x, out float y, out float z)
        {
            float angle1 = Range(Xorshift.RADIAN_MIN, Xorshift.RADIAN_MAX);
            float angle2 = Range(Xorshift.RADIAN_MIN, Xorshift.RADIAN_MAX);

            x = (float)(System.Math.Sin(angle1) * System.Math.Cos(angle2));
            y = (float)(System.Math.Sin(angle1) * System.Math.Sin(angle2));
            z = (float)(System.Math.Cos(angle1));
        }

        /// <summary>
        /// 単位球内のランダムな点の座標を取得します。
        /// </summary>
        /// <param name="x">
        /// 単位球内のランダムな点の X 座標。
        /// </param>
        /// <param name="y">
        /// 単位球内のランダムな点の Y 座標。
        /// </param>
        /// <param name="z">
        /// 単位球内のランダムな点の Z 座標。
        /// </param>
        public void InsideUnitSphere(out float x, out float y, out float z)
        {
            OnUnitSphere(out x, out y, out z);

            float radius = Value();

            x *= radius;
            y *= radius;
            z *= radius;
        }

        #endregion Method
    }
}
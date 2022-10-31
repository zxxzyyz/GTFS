using System;
using System.Collections.Generic;
using System.Text;
using ProtoGTFS.Common;

namespace ProtoGTFS
{
    class UserMaster
    {
        //public void Create(DateTime startDateG1, DateTime startDateG2)
        //{
        //    var bytes = new List<byte>();

        //    // 事業者独自マスタヘッダSUM
        //    bytes.AddRange(Utility.ToBytes(0, 1, true));

        //    // リビジョン
        //    bytes.AddRange(Utility.ToBytes(1, 1, true));

        //    // user_mst.bin更新日
        //    bytes.AddRange(Utility.ToBytes(DateTime.Now.ToString("yyyyMMddHHmmss"), 7, false));

        //    // 事業者独自マスタ数
        //    bytes.AddRange(Utility.ToBytes(3, 1, true));

        //    // 事業者独自マスタ開始アドレス
        //    bytes.AddRange(Utility.ToBytes(48, 4, true));

        //    // 事業者独自マスタサイズ
        //    bytes.AddRange(Utility.ToBytes(3, 4, true));

        //    // 停留所名マスタ開始アドレス
        //    bytes.AddRange(Utility.ToBytes(64, 4, true));

        //    //--------------------------------------------// 停留所名マスタサイズ
        //    bytes.AddRange(Utility.ToBytes(0, 4, true));

        //    // 空港・深夜急行線マスタ開始アドレス
        //    bytes.AddRange(Utility.ToBytes(0, 4, true));

        //    //--------------------------------------------// 空港・深夜急行線マスタサイズ
        //    bytes.AddRange(Utility.ToBytes(0, 4, true));

        //    // 事業者マスタSUM
        //    bytes.AddRange(Utility.ToBytes(0, 1, true));

        //    // 事業者登録数
        //    bytes.AddRange(Utility.ToBytes(0, 2, true));

        //    // 停留所名マスタ開始位置調整
        //    bytes.AddRange(Utility.ToBytes(0, bytes.Count + (16 - (bytes.Count % 16)), true));

        //    //--------------------------------------------// 停留所名マスタSUM
        //    bytes.AddRange(Utility.ToBytes(0, 1, true));

        //    // 第一世代開始日
        //    bytes.AddRange(Utility.ToBytes(startDateG1.ToString("yyyyMMdd"), 4, false));

        //    // 第二世代開始日
        //    bytes.AddRange(Utility.ToBytes(startDateG2.ToString("yyyyMMdd"), 4, false));
        //}

        public void Read()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yj.ArcSoftSDK.Pro._1_0.Models
{
    internal struct ASF_FaceAttributeInfo
    {
        /// <summary>
        /// 戴眼镜置信度 [0-1]
        /// <see cref="float"/>
        /// </summary>
        public nint Wear_glasses;
        /// <summary>
        /// 戴墨镜置信度 [0-1]
        /// <see cref="float"/>
        /// </summary>
        public nint Wear_black_glasses;
    }
}

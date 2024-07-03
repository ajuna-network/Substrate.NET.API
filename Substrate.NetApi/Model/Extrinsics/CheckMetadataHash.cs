using System.Collections.Generic;
using System.Linq;
using Substrate.NetApi.Model.Types.Base;
using System;
using Newtonsoft.Json;
using Substrate.NetApi.Model.Types;



namespace Substrate.NetApi.Model.Extrinsics
{

        /// <summary>
        ///  If the runtime should expect a metadata hash that has been signed in the addional signed.
        /// </summary>  
        public enum Mode
        {
            Disabled,
            Enabled
        }
    public class CheckMetadataHash: BaseType
    {



        Mode _mode;

        public CheckMetadataHash() { 
            // Don't allow enabling the mode, as we don't support it.
            _mode = Mode.Disabled;
        }

        /// <summary> <summary>
        /// Corresponds to the `Extra` that is sent with the extrinsic.
        /// </summary>
        /// <returns></returns>
        public override byte[] Encode()
        {
            return EncodeExtra();
        }

        /// <summary> <summary>
        /// Simplifies the calling code a bit, as we only need this in static contexts for now `Encode`.
        /// </summary>
        /// <returns></returns>
        static public byte[] EncodeExtra()
        {
            // // We provide no metadata hash in the signer payload to align with the above.
            return new byte[1];
        }

        /// <summary> <summary>
        /// Corresponds to the `Addional` that is signed, but _not_ sent with the extrinsic.
        /// </summary>
        /// <returns></returns>
        static public byte[] EncodeAdditional()
        {
            // // We provide no metadata hash in the signer payload to align with the above.
            return new byte[1];
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            uint modeByte = byteArray[p++];

            if (modeByte > 1) {
                throw new ArgumentException($"{modeByte} is not a valid representation of CheckMetadata Mode.");
            }

            if (modeByte == 0) {
                _mode = Mode.Disabled;
            } else {
                _mode = Mode.Enabled;
            }
        }
    }
}
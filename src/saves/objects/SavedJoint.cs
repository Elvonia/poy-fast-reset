using PeterO.Cbor;
using UnityEngine;

namespace FastReset.Saves {
    public class SavedJoint : BaseSaved {
        // The saved state
        public Quaternion rotation = Quaternion.identity;

        public override CBORObject ToCBOR () {
            return CBORObject.NewMap()
                .Add("id", id)
                .Add("rot", SaveManager.QuatToBytes(rotation));
        }

        public SavedJoint(byte[] id) : base(id) {}

        public SavedJoint(CBORObject cbor) {
            id = cbor["id"].EncodeToBytes();
            rotation = SaveManager.BytesToQuat(cbor["rot"].EncodeToBytes());
        }
    }
}

﻿using EncodingLib;

namespace Quartz.Proto.Play.Server
{
    public sealed class EntityVelocity : OutPacket
    {
        public int EntityId { get; set; }
        public short VelocityX { get; set; }
        public short VelocityY { get; set; }
        public short VelocityZ { get; set; }

        public override void Write(PrimitiveWriter writer)
        {
            writer.WriteVarint(EntityId);
            writer.WriteShort(VelocityX);
            writer.WriteShort(VelocityY);
            writer.WriteShort(VelocityZ);
        }
    }
}

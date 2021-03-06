﻿using EncodingLib;

namespace Quartz.Proto.Play.Server
{
    public sealed class Animation : OutPacket
    {
        public int EntityId { get; set; }
        public AnimationEnum Anim { get; set; }

        public override void Write(PrimitiveWriter writer)
        {
            writer.WriteVarint(EntityId);
            writer.WriteByte((byte)Anim);
        }

        public enum AnimationEnum
        {
            SwingMainArm,
            TakeDamage,
            LeaveBed,
            SwingOffhand,
            CriticalEffect,
            MagicCriticalEffect
        }
    }
}

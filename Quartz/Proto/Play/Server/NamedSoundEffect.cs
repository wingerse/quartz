﻿using EncodingLib;
using Quartz.Math;
using Quartz.Sound;

namespace Quartz.Proto.Play.Server
{
    public sealed class NamedSoundEffect : OutPacket
    {
        public string Name { get; set; }
        public SoundCategory Category { get; set; }
        public Vec3 Position { get; set; }
        public float Volume { get; set; }
        public float Pitch { get; set; }
        
        public override void Write(PrimitiveWriter writer)
        {
            writer.WriteStringProto(Name);
            writer.WriteVarint(Category.Id);
            writer.WriteInt((int)(Position.X * 8));
            writer.WriteInt((int)(Position.Y * 8));
            writer.WriteInt((int)(Position.Z * 8));
            writer.WriteFloat(Volume);
            writer.WriteFloat(Pitch);
        }
    }
}

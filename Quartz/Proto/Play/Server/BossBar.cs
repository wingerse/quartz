﻿using System;
using EncodingLib;
using Quartz.Text.Chat;

namespace Quartz.Proto.Play.Server
{
    public sealed class BossBar : OutPacket
    {
        public Bossbar Bossbar { get; set; }
        public ActionEnum Action { get; set; }

        public override void Write(PrimitiveWriter writer)
        {
            writer.WriteUuidProto(Bossbar.Uuid);
            writer.WriteVarint((int)Action);
            switch (Action)
            {
                case ActionEnum.Add:
                    writer.WriteChatRootProto(Bossbar.Title);
                    writer.WriteFloat(Bossbar.Health);
                    writer.WriteVarint((int)Bossbar.Color);
                    writer.WriteVarint((int)Bossbar.Division);
                    byte x = 0;
                    if (Bossbar.ShouldDarkenSky) x |= 0x1;
                    if (Bossbar.IsDragonBar) x |= 0x02;
                    writer.WriteByte(x);
                    break;
                case ActionEnum.Remove:
                    break;
                case ActionEnum.UpdateHealth:
                    writer.WriteFloat(Bossbar.Health);
                    break;
                case ActionEnum.UpdateTitle:
                    writer.WriteChatRootProto(Bossbar.Title);
                    break;
                case ActionEnum.UpdateStyle:
                    writer.WriteVarint((int)Bossbar.Color);
                    writer.WriteVarint((int)Bossbar.Division);
                    break;
                case ActionEnum.UpdateFlags:
                    byte z = 0;
                    if (Bossbar.ShouldDarkenSky) z |= 0x1;
                    if (Bossbar.IsDragonBar) z |= 0x02;
                    writer.WriteByte(z);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid ActionEnum: {Action}");
            }
        }

        public enum ActionEnum
        {
            Add,
            Remove,
            UpdateHealth,
            UpdateTitle,
            UpdateStyle,
            UpdateFlags
        }
    }
}

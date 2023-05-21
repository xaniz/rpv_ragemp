using GTANetworkAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;


class BasicSync : Script
{

    public static void AttachLabelToObject(string text, Vector3 posOffset, NetHandle obj)
    {
        var attachedLabel = new AttachedLabel(text, posOffset);
        switch (obj.Type)
        {
            case EntityType.Player:
                var player = NAPI.Entity.GetEntityFromHandle<Player>(obj);
                player.SetSharedData("attachedLabel", JsonConvert.SerializeObject(attachedLabel));
                Trigger.ClientEventInRange(player.Position, 550, "attachLabel", player);
                break;
            case EntityType.Vehicle:
                var vehicle = NAPI.Entity.GetEntityFromHandle<Vehicle>(obj);
                vehicle.SetSharedData("attachedLabel", JsonConvert.SerializeObject(attachedLabel));
                Trigger.ClientEventInRange(vehicle.Position, 550, "attachLabel", vehicle);
                break;
        }
    }

    public static void DetachLabel(NetHandle obj)
    {
        switch (obj.Type)
        {
            case EntityType.Player:
                var player = NAPI.Entity.GetEntityFromHandle<Player>(obj);
                player.ResetSharedData("attachedLabel");
                Trigger.ClientEventInRange(player.Position, 550, "detachLabel");
                break;
            case EntityType.Vehicle:
                var vehicle = NAPI.Entity.GetEntityFromHandle<Vehicle>(obj);
                vehicle.ResetSharedData("attachedLabel");
                Trigger.ClientEventInRange(vehicle.Position, 550, "detachLabel");
                break;
        }
    }

    public static void AttachObjectToPlayer(Player player, uint model, int bone, Vector3 posOffset, Vector3 rotOffset)
    {
        var attObj = new AttachedObject(model, bone, posOffset, rotOffset);
        player.SetSharedData("attachedObject", JsonConvert.SerializeObject(attObj));
        Trigger.ClientEventInRange(player.Position, 550, "attachObject", player);
    }

    public static void DetachObject(Player player)
    {
        player.ResetSharedData("attachedObject");
        Trigger.ClientEventInRange(player.Position, 550, "detachObject", player);
    }

    private static string SerializeAttachments(List<uint> attachments)
    {
        return string.Join('|', attachments.Select(hash => hash.ToString("X")));
    }

    [ServerEvent(Event.PlayerConnected)]
    public void OnPlayerConnected(Player player)
    {
        player.SetData("ATTACHMENTS", new List<uint>());
    }

    public static bool GetInvisible(Player player)
    {
        if (!player.HasSharedData("INVISIBLE") || !player.GetSharedData<bool>("INVISIBLE"))
            return false;
        else
            return true;
    }

    internal class PlayAnimData
    {
        public string Dict { get; set; }
        public string Name { get; set; }
        public int Flag { get; set; }

        public PlayAnimData(string dict, string name, int flag)
        {
            Dict = dict;
            Name = name;
            Flag = flag;
        }
    }

    internal class AttachedObject
    {
        public uint Model { get; set; }
        public int Bone { get; set; }
        public Vector3 PosOffset { get; set; }
        public Vector3 RotOffset { get; set; }

        public AttachedObject(uint model, int bone, Vector3 pos, Vector3 rot)
        {
            Model = model;
            Bone = bone;
            PosOffset = pos;
            RotOffset = rot;
        }
    }

    internal class AttachedLabel
    {
        public string Text { get; set; }
        public Vector3 PosOffset { get; set; }

        public AttachedLabel(string text, Vector3 pos)
        {
            Text = text;
            PosOffset = pos;
        }
    }


}
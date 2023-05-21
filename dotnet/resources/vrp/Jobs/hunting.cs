/*using GTANetworkAPI;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Timers;

public class Hunting : Script
{
    public Hunting()
    {
    }

    public static List<HuntingAnimal> SpawnedAnimals = new List<HuntingAnimal>();
    private static Random Rnd = new Random();
    public static int Interval = 1000;

    // Defining of the animals.
    public enum Animals
    {
        Deer,
        Boar,
    }

    // Animals have three states, Grazing, Wandering, and Fleeing.
    public enum AnimalStates
    {
        Fleeing,
        Grazing,
        Wandering,
    }

    public static Vector3[] AnimalSpawnPoints =
    {
        new Vector3(-1725.521, 4699.659, 33.80555),
        new Vector3(-1690.836, 4682.494, 24.47228),
        new Vector3(-1661.219, 4650.042, 26.12522),
        new Vector3(-1613.11, 4632.693, 46.37965),
        new Vector3(-1569.1, 4688.946, 48.04772),
        new Vector3(-1549.585, 4766.055, 60.47577),
        new Vector3(-1461.021, 4702.999, 39.26906),
        new Vector3(-1397.87, 4637.824, 72.12587),
        new Vector3(-617.851, 5762.557, 31.45378),
        new Vector3(-613.3984, 5863.435, 22.00531),
        new Vector3(-512.6949, 5940.441, 34.46115),
        new Vector3(-363.9753, 5921.967, 43.97315),
        new Vector3(-384.0528, 5866.263, 49.28809),
        new Vector3(-374.6584, 5798.462, 62.83068),
        new Vector3(-448.7513, 5565.69, 71.9878),
        new Vector3(-551.2087, 5167.825, 97.50465),
        new Vector3(-603.5089, 5154.867, 110.1652),
        new Vector3(-711.7279, 5149.544, 114.7229),
        new Vector3(-711.3442, 5075.649, 138.9036),
        new Vector3(-672.9759, 5042.516, 152.8032),
        new Vector3(-661.6283, 4974.586, 172.7258),
        new Vector3(-600.277, 4918.438, 176.7214),
        new Vector3(-588.3793, 4889.981, 181.3767),
        new Vector3(-549.8376, 4838.274, 183.2239),
        new Vector3(-478.639, 4831.655, 209.2594),
        new Vector3(-399.3954, 4865.303, 203.7752),
        new Vector3(-411.9441, 4946.082, 177.4535),
        new Vector3(-414.8653, 5074.294, 149.0627),
    };

    [Command("pickup", "~y~/pickup")]
    public void CMD_PICKUP(Player sender)
    {
        foreach (var animal in SpawnedAnimals)
        {
            if (sender.Position.DistanceTo(NAPI.Entity.GetEntityPosition(animal.handle)) < 2.0)
            {
                // Checks if the animal is dead or dying.
                bool isDead = NAPI.Native.FetchNativeFromPlayer<bool>(sender, Hash.IS_PED_DEAD_OR_DYING, animal.handle, true);
                if (isDead)
                {
                    // Removes and spawns a new animal.
                    animal.Respawn();
                }
                else
                {
                    NAPI.Chat.SendChatMessageToPlayer(sender, "~r~Ova zivotinja je ziva!");
                }
                return;
            }
        }
    }
    
    [RemoteEvent("update_animal_position")]
    public void UpdateAnimalPosition(Player player, params object[] arguments)
    {
        NAPI.Entity.SetEntityPosition((NetHandle)arguments[0], (Vector3)arguments[1]);
    }

    public static Vector3 RandomFarawayDestination(Vector3 currentPos)
    {
        var choices = Array.FindAll(AnimalSpawnPoints, spawn => spawn.DistanceTo(currentPos) > 5);
        return choices[Rnd.Next(choices.Length)];
    }

    public void OnScriptStart()
    {
        int i = 0;
        foreach (var spawn in AnimalSpawnPoints)
        {
            if (i == 0)
            {
                new HuntingAnimal(spawn, Animals.Deer, AnimalStates.Wandering).updateState = true;
                i = 1;
            }
            else
            {
                new HuntingAnimal(spawn, Animals.Boar, AnimalStates.Wandering).updateState = true;
                i = 0;
            }
        }
        NAPI.Util.ConsoleOutput("[HUNTING] Created " + SpawnedAnimals.Count + " animals.");
    }

    public class HuntingAnimal
    {
        public Ped handle;
        public Vector3 Spawn;
        public Animals Type;
        public AnimalStates State;

        public Timer stateTimer;
        public int stateChangeTick;
        public Vector3 Destination;
        public bool updateState;
        public Player FleeingPed;

        // Handles each animal and it's current state.
        public HuntingAnimal(Vector3 spawn, Animals type, AnimalStates state)
        {
            handle = NAPI.Ped.CreatePed((type == Animals.Deer) ? (PedHash.Deer) : (PedHash.Boar), spawn, 0, 0);

            Spawn = spawn;
            Type = type;
            State = state;

            stateTimer = new Timer()
            {
                Interval = Interval,
                AutoReset = true
            };
            stateTimer.Elapsed += delegate { AnimalAi(this); };
            stateTimer.Start();
            SpawnedAnimals.Add(this);
        }

        // Handles the animals position relative to the server and deals with state updating.
        public void AnimalAi(HuntingAnimal animal)
        {
            if (handle == null)
                return;

            List<Player> playersInRadius = new List<Player>();

            foreach (var player in NAPI.Pools.GetAllPlayers())
            {
                if (player == null)
                    continue;

                // Every player within the radius will be added to a list of clients.
                if (player.Position.DistanceTo(NAPI.Entity.GetEntityPosition(handle)) <= 100)
                {
                    playersInRadius.Add(player);
                }
            }

            if (playersInRadius.Count == 0)
            {
                return;
            }
            NAPI.ClientEvent.TriggerClientEvent(playersInRadius[0], "update_animal_position", handle);

            // Syncs the animals death to every player nearby.
            foreach (var player in playersInRadius)
            {
                bool isDead = NAPI.Native.FetchNativeFromPlayer<bool>(player, Hash.IS_PED_DEAD_OR_DYING, handle, true);
                if (isDead)
                {
                    foreach (var p in playersInRadius)
                        NAPI.ClientEvent.TriggerClientEvent(p, "update_animal_death", this.handle);
                }
            }

            // If there are players near the animal, and it's not already fleeing, then make it flee.
            if (playersInRadius.Count > 0 && State != AnimalStates.Fleeing)
            {
                State = AnimalStates.Fleeing;
                FleeingPed = playersInRadius.First();
                updateState = true;
            }

            stateChangeTick++;

            // Automatic state updating.
            if (State != AnimalStates.Fleeing)
            {
                if (stateChangeTick > 15)
                {
                    var nextStateChance = Rnd.Next(100);
                    if (nextStateChance < 30)
                    {
                        State = AnimalStates.Grazing;
                        NAPI.Ped.PlayPedScenario(handle, Type == Animals.Deer ? "WORLD_DEER_GRAZING" : "WORLD_PIG_GRAZING");
                    }
                    else
                    {
                        State = AnimalStates.Wandering;
                        Destination = RandomFarawayDestination(NAPI.Entity.GetEntityPosition(handle));
                        updateState = true;
                    }
                    stateChangeTick = 0;
                }
            }
            else
            {
                // Make the animal stop fleeing and go back to grazing the land.
                if (stateChangeTick > 20)
                {
                    State = AnimalStates.Grazing;
                    NAPI.Ped.PlayPedScenario(handle, Type == Animals.Deer ? "WORLD_DEER_GRAZING" : "WORLD_PIG_GRAZING");
                    stateChangeTick = 0;
                }
            }

            if (updateState != true)
                return;
            switch (State)
            {
                case AnimalStates.Fleeing:
                    foreach (var p in playersInRadius)
                    {
                        NAPI.Native.SendNativeToPlayer(p, Hash.TASK_SMART_FLEE_PED, handle, FleeingPed.Handle, 75f, 5000, 0, 0);
                    }
                    break;

                case AnimalStates.Grazing:
                    NAPI.Ped.PlayPedScenario(handle, Type == Animals.Deer ? "WORLD_DEER_GRAZING" : "WORLD_PIG_GRAZING");
                    break;

                case AnimalStates.Wandering:
                    foreach (var p in playersInRadius)
                    {
                        NAPI.Native.SendNativeToPlayer(p, Hash.TASK_WANDER_IN_AREA, handle, Destination.X, Destination.Y, Destination.Z, 25, 0, 0);
                    }
                    break;

            }
            updateState = false;
        }

        public void Respawn()
        {
            if (NAPI.Entity.DoesEntityExist(handle))
                NAPI.Entity.DeleteEntity(handle);

            handle = NAPI.Ped.CreatePed((Type == Animals.Deer) ? (PedHash.Deer) : (PedHash.Boar), Spawn, 0, 0);
        }
    }
}*/
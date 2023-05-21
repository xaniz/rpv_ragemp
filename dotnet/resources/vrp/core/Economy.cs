using GTANetworkAPI;

class Economy : Script
{
    public static int XP_RATE = 20;
    public static int XP_RATE_HOURLY = 1;

    public static int CLOTHE_STORE_PRICE_BIQUINI = 300;

    public static int PRECO_MUNICAO_SNIPER = 5000;
    public static int PRECO_MUNICAO_ASSAULT = 2500;
    public static int PRECO_MUNICAO_SHOTGUN = 1000;
    public static int PRECO_MUNICAO_pistol = 1000;
    public static int PRECO_MUNICAO_SMG = 2000;

    public static int[] SHIPMENT_BUSINESS_REESTOCK = new int[11] {
        0, 
        100000, 
        100000, 
        200000,
        300000,
        200000,
        240000, 
        200000, 
        200000,
        200000, 
        50000 };
    public enum SHIPMENT_ENUM
    {
        undefine = 0,
        Clothing_store = 1,
        Superi = 2,
        Gun_Store = 3,
        Car_Dealership = 4,
        Gas_Station = 5,
        Motorcrycle = 6,
        Boat_Dealdership = 7,
        Aircraft_Dealership = 8,
        Truck_Dealersip = 9,
        Salmoni = 10
    }

    //public static int SHIPMENT_BUSINESS_REESTOCK = 200000;

    public static int HAMBURGUER = 500;
    public static int ENERGY_DRINK = 500;
    public static int PLAYER_TO_START_WAR = 1;

    public static int VEHICLE_RENT_FAGGIO = 500;
    public static int VEHICLE_RENT_ASEA = 2500;


}


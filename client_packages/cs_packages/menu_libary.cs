using Newtonsoft.Json;
using RAGE;
using RAGE.Elements;
using RAGE.NUI;
using System.Collections.Generic;


class Menu_Libary : Events.Script
{
    public static bool ketchup = false;
    public static bool menu_status = false;
    public static string dish = "Banana";
    public static MenuPool _menuPool = new MenuPool();


    public class LibaryModel
    {
        public int Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RightLabel { get; set; }
        public string Color { get; set; }
        public string HighlightColor { get; set; }
        public string LeftBadge { get; set; }
        public string RightBadge { get; set; }
        public List<string> List { get; set; }
        public int StartIndex { get; set; }
        public bool IsTicked { get; set; }
        public System.Drawing.Color color { get; set; }
    }

    public class MenuCustomization
    {
        public bool Sprite_Active { get; set; }
        public string Sprite { get; set; }

        public bool Background_Active { get; set; }
        public System.Drawing.Color Background { get; set; }
    }

    public Menu_Libary()
    {


        // _menuPool = new MenuPool();

        RAGE.Events.Tick += DrawMenu;

        
        Events.Add("menu_handler_create_menu_generic", OnCreateMenu);
        Events.Add("menu_dynamic_close", OnForceCloseMenu);
        Events.Add("check_client_csharp", CheckClientIsWorking);
        
    }

    public void CheckClientIsWorking(object[] args)
    {
        Events.CallRemote("client_side_enable");
    }
    
    

public static void OnForceCloseMenu(object[] args)
    {
        _menuPool.CloseAllMenus();
        menu_status = false;
        Events.CallLocal("menu_libary", false);

    }

    public static UIMenuItem.BadgeStyle Name_To_Badge(string badge_name)
    {
        switch (badge_name)
        {
            case "Alert": return UIMenuItem.BadgeStyle.Alert;
            case "Ammo": return UIMenuItem.BadgeStyle.Ammo;
            case "Armour": return UIMenuItem.BadgeStyle.Armour;
            case "Barber": return UIMenuItem.BadgeStyle.Barber;
            case "Bike": return UIMenuItem.BadgeStyle.Bike;
            case "BronzeMedal": return UIMenuItem.BadgeStyle.BronzeMedal;
            case "Car": return UIMenuItem.BadgeStyle.Car;
            case "Clothes": return UIMenuItem.BadgeStyle.Clothes;
            case "Crown": return UIMenuItem.BadgeStyle.Crown;
            case "Franklin": return UIMenuItem.BadgeStyle.Franklin;
            case "GoldMedal": return UIMenuItem.BadgeStyle.GoldMedal;
            case "Gun": return UIMenuItem.BadgeStyle.Gun;
            case "Heart": return UIMenuItem.BadgeStyle.Heart;
            case "Lock": return UIMenuItem.BadgeStyle.Lock;
            case "Makeup": return UIMenuItem.BadgeStyle.Makeup;
            case "Mask": return UIMenuItem.BadgeStyle.Mask;
            case "Michael": return UIMenuItem.BadgeStyle.Michael;
            case "None": return UIMenuItem.BadgeStyle.None;
            case "SilverMedal": return UIMenuItem.BadgeStyle.SilverMedal;
            case "Star": return UIMenuItem.BadgeStyle.Star;
            case "Tatoo": return UIMenuItem.BadgeStyle.Tatoo;
            case "Tick": return UIMenuItem.BadgeStyle.Tick;
            case "Trevor": return UIMenuItem.BadgeStyle.Trevor;
        }
        return UIMenuItem.BadgeStyle.None;
    }

    public static void OnCreateMenu(object[] args)
    {

        string variable_menu_callback = args[0].ToString();
        string variable_menu_name = args[1].ToString();
        string variable_menu_description = args[2].ToString();
        bool variable_menu_freeze = (bool)args[3];
        var menu_item_data = JsonConvert.DeserializeObject<List<LibaryModel>>((string)args[4]);
        bool variable_menu_reset_key = (bool)args[5];
        string variable_menu_sprite = args[6].ToString();
        string variable_menu_color = args[7].ToString();
        int variable_menu_currentSelect = (int)args[8];
        bool variable_menu_mouseControl = (bool)args[9];


        var mainMenu = new UIMenu(variable_menu_name, variable_menu_description, new System.Drawing.Point(1200, 280));


        /* if (menu_customization.Background_Active == true)
         {
             var banner = new UIResRectangle();
             banner.Color = menu_customization.Background;
             mainMenu.SetBannerType(banner);
         }*/

        if (variable_menu_sprite != "none")
        {
            if (variable_menu_sprite.Contains(".jpg"))
            {
                mainMenu.SetBannerType(variable_menu_sprite); // Extracted from zip

            }
            else
            {
                var banner = new Sprite(variable_menu_sprite, variable_menu_sprite, new System.Drawing.Point(0), new System.Drawing.Size(0, 0));
                mainMenu.SetBannerType(banner);
            }
        }
        else if (variable_menu_color != "none")
        {
            var banner = new UIResRectangle();
            banner.Color = System.Drawing.Color.FromName(variable_menu_color);
            mainMenu.SetBannerType(banner);
        }


        if (variable_menu_mouseControl == true)
        {
            mainMenu.MouseControlsEnabled = true;
        }
        else
        {
            mainMenu.MouseControlsEnabled = false;
        }

        if (variable_menu_freeze == true)
        {
            mainMenu.FreezeAllInput = true;
        }

        _menuPool.Add(mainMenu);


        //mainMenu.set

        for (int i = 0; i < menu_item_data.Count; i++)
        {
            if (menu_item_data[i].Type == 1 || menu_item_data[i].Type == 4)
            {
                var newitem = new UIMenuItem(menu_item_data[i].Name, menu_item_data[i].Description);

                try
                {
                    if (menu_item_data[i].Color != null) newitem = new UIMenuColoredItem(menu_item_data[i].Name, menu_item_data[i].Description, System.Drawing.Color.FromName(menu_item_data[i].Color), System.Drawing.Color.FromName(menu_item_data[i].HighlightColor));
                }
                catch { }

                try
                {
                    if (menu_item_data[i].RightLabel != null) newitem.SetRightLabel(menu_item_data[i].RightLabel);
                }
                catch { }

                try
                {
                    if (menu_item_data[i].LeftBadge != null) newitem.SetLeftBadge(Name_To_Badge(menu_item_data[i].LeftBadge));
                }
                catch { }

                try
                {
                    if (menu_item_data[i].RightBadge != null) newitem.SetRightBadge(Name_To_Badge(menu_item_data[i].RightBadge));
                }
                catch { }



                mainMenu.AddItem(newitem);
                mainMenu.OnItemSelect += (sender, item, index) =>
                {
                    if (item == newitem)
                    {
                        Events.CallLocal("menu_libary", false);
                        menu_status = false;
                        mainMenu.Visible = false;
                        
                        Events.CallRemote("menu_handler_select_item_generic", variable_menu_callback, index, item.Text, "");
                    }
                };
                mainMenu.OnIndexChange += (sender, index) =>
                {
                    Events.CallRemote("menu_handler_index_change_generic", variable_menu_callback, index, menu_item_data[index].Name, "");
                    
                };
            }
            else if (menu_item_data[i].Type == 6 || menu_item_data[i].Type == 2 || menu_item_data[i].Type == 3)
            {

                var foods = new List<dynamic>();

                for (int b = 0; b < menu_item_data[i].List.Count; b++)
                {
                    foods.Add(menu_item_data[i].List[b]);
                }
                var newitem = new UIMenuListItem(menu_item_data[i].Name, foods, menu_item_data[i].StartIndex);
                newitem.Description = menu_item_data[i].Description;
                mainMenu.AddItem(newitem);

                int nindex = 0;
                mainMenu.OnListChange += (sender, item, index) =>
                {
                    if (item == newitem)
                    {
                        nindex = index;
                        Events.CallRemote("menu_handler_listchanged_item_generic", variable_menu_callback, mainMenu.CurrentSelection, item.Text, item.IndexToItem(index).ToString(), index);
                    }
                };

                try
                {
                    if (menu_item_data[i].LeftBadge != null) newitem.SetLeftBadge(Name_To_Badge(menu_item_data[i].LeftBadge));
                }
                catch { }

                try
                {
                    if (menu_item_data[i].RightBadge != null) newitem.SetRightBadge(Name_To_Badge(menu_item_data[i].RightBadge));
                }
                catch { }
               

                if (menu_item_data[i].Type == 2)
                {
                    mainMenu.OnItemSelect += (sender, item, index) =>
                    {
                        if (item == newitem)
                        {
                            Events.CallLocal("menu_libary", false);
                            menu_status = false;
                            mainMenu.Visible = false;
                            Events.CallRemote("menu_handler_select_item_generic", variable_menu_callback, index, item.Text, newitem.IndexToItem(nindex).ToString());
                        }

                    };
                }
                else if (menu_item_data[i].Type == 6)
                {
                    mainMenu.OnItemSelect += (sender, item, index) =>
                    {
                        if (item == newitem)
                        {
                            //Events.CallLocal("menu_libary", false);
                            //menu_status = false;
                            //mainMenu.Visible = false;
                            Events.CallRemote("menu_handler_select_item_generic", variable_menu_callback, index, item.Text, newitem.IndexToItem(nindex).ToString());
                        }
                    };
                }
            }
            else if (menu_item_data[i].Type == 5)
            {
                var newitem = new UIMenuCheckboxItem(menu_item_data[i].Name, menu_item_data[i].IsTicked, menu_item_data[i].Description);
                mainMenu.AddItem(newitem);
                mainMenu.OnCheckboxChange += (sender, item, checked_) =>
                {
                    if (item == newitem)
                    {
                        Events.CallRemote("menu_handler_checked_item_generic", variable_menu_callback, mainMenu.CurrentSelection, item.Text, "", checked_);
                    }
                };

                try
                {
                    if (menu_item_data[i].LeftBadge != null) newitem.SetLeftBadge(Name_To_Badge(menu_item_data[i].LeftBadge));
                }
                catch { }

                try
                {
                    if (menu_item_data[i].RightBadge != null) newitem.SetRightBadge(Name_To_Badge(menu_item_data[i].RightBadge));
                }
                catch { }
            }
        }

        if (variable_menu_callback == "PLAY_ANIMATION")
        {

            var myButton = new InstructionalButton("K", "Adicionar Atalho");
            mainMenu.AddInstructionalButton(myButton);

        }

        //mainMenu.CurrentSelection = variable_menu_currentSelect;

        if (variable_menu_reset_key == true)
        {
            mainMenu.ResetKey(UIMenu.MenuControls.Back);

        }


        mainMenu.OnMenuClose += (sender) =>
        {
            Events.CallRemote("menu_handler_on_close", variable_menu_callback);
            Events.CallLocal("menu_libary", false);
            menu_status = false;
        };

        _menuPool.RefreshIndex();

        if (_menuPool.IsAnyMenuOpen() == false)
        {
            mainMenu.Visible = true;
        }
        menu_status = true;
        Events.CallLocal("menu_libary", true);
    }

    public void DrawMenu(System.Collections.Generic.List<RAGE.Events.TickNametagData> nametags)
    {
        _menuPool.ProcessMenus();
    }

}

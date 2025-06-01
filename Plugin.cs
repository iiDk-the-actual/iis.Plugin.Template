using static iiMenu.Menu.Main;
using iiMenu.Classes;
using iiMenu.Mods;
using UnityEngine;

namespace StupidPlugin
{
    public class Plugin
    {
        /*
            Plugin template used for ii's Stupid Menu 6.1.0+

            If you've ever created a menu before, this should be easy:
                + GetIndex(ButtonName); Gets a button's ButtonInfo
                + AddButton(CategoryID, new ButtonInfo); Creates a button in a category
                - RemoveButton(CategoryID, ButtonName); Removes a button in a category

                + GetCategory(CategoryName); Gets a category, you can find the category names in the menu's Buttons.cs file at the bottom
                + AddCategory(CategoryName); Creates a category, does not automatically create the navigation button
                - RemoveCategory(CategoryName); Removes the category created, does not automatically

            Feel free to modify, add, or remove any methods or fields below
        */

        public static string Name = "Example Plugin";
        public static string Description = "An example plugin used for testing.";

        // This runs when the plugin starts, at the beginning of the game if enabled before launch
        // You should put all of your adding of buttons / categories here
        public static void OnEnable()
        {
            UnityEngine.Debug.Log("Plugin " + Name + " has been enabled!");

            int category = AddCategory("Plugin Mods");
            AddButton(GetCategory("Main"), new ButtonInfo { buttonText = "Plugin Mods", method = delegate { currentCategoryIndex = category; }, isTogglable = false, toolTip = "Brings you to a category for plugins." });
            AddButton(category, new ButtonInfo { buttonText = "Exit Plugin Mods", method =() => currentCategoryName = "Main", isTogglable = false, toolTip = "Returns you back to the main page." });

            AddButton(category, new ButtonInfo { buttonText = "Right Trigger Fly <color=grey>[</color><color=green>RT</color><color=grey>]</color>", method = () => RightTriggerFly(), toolTip = "Returns you back to the main page." });
        }

        // This runs when the plugin stops, or when plugins are reloaded
        // You should put all of your removing of buttons / categories here
        public static void OnDisable()
        {
            UnityEngine.Debug.Log("Plugin " + Name + " has been disabled!");

            RemoveCategory("Plugin Mods");
            RemoveButton(GetCategory("Main"), "Plugin Mods");
        }

        // This runs every frame before the mods
        public static void Update()
        {
            // UnityEngine.Debug.Log(Time.time);
        }

        // This runs when the menu UI is open (togglable with backslash)
        // I don't recommend using this as an update method
        public static void OnGUI()
        {
            // GUI.Button(new Rect(10, 10, 200, 100), "Test Button");
        }

        // Example mod
        private static void RightTriggerFly()
        {
            if (rightTrigger > 0.5f)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * Movement.flySpeed;
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }
}

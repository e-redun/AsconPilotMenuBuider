namespace CommonLib.Services.MenuBuilder
{
    public class MenuItemFactory
    {
        public static ToolbarButtonItem CreateMenuItem(MenuItemTypes itemType)
        {
            switch (itemType)
            {
                case MenuItemTypes.Button:
                    return new ToolbarButtonItem();

                case MenuItemTypes.ToggleButton:
                    return new ToolbarToggleButtonItem();
            }

            return null;
        }
    }
}

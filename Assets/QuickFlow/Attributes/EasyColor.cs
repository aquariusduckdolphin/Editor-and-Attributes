using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuickFlow
{


    /// <summary>
    /// https://www.rapidtables.com/web/color/RGB_Color.html
    /// </summary>
    public enum QuickColors
    {

        Clear,
        White,
        Black,
        Grey,
        Brown,
        Red,
        Yellow,
        Blue,
        Green,
        Orange,
        Violet,
        Magenta,
        Red_Orange,
        Yellow_Orange,
        Yellow_Green,
        Blue_Green,
        Blue_Violet,
        Red_Violet,
        Lime,
        Cyan,
        Silver,
        Maroon,
        Olive,
        Purple,
        Teal,
        Navy,

        clear,
        maroon,
        darkRed,
        brown,
        firebrick,
        crimson,
        red,
        tomato,
        coral,
        indianRed,
        lightCoral,
        darkSalmon,
        salmon,
        lightSalmon,
        orangeRed,
        darkOrange,
        orange,
        gold,
        darkGoldenRod,
        goldenRod,
        paleGoldenRod,
        darkKhaki,
        khaki,
        olive,
        yellow,
        yellowGreen,
        darkOliveGreen,
        oliveDrab,
        lawnGreen,
        chartreuse,
        greenYellow,
        darkGreen,
        green,
        forestGreen,
        lime,
        limeGreen,
        lightGreen,
        paleGreen,
        darkSeaGreen,
        mediumSpringGreen,
        springGreen,
        seaGreen,
        mediumAquaMarine,
        mediumSeaGreen,
        lightSeaGreen,
        darkSlateGray,
        teal,
        darkCyan,
        cyan,
        lightCyan,
        darkTurquoise,
        turquoise,
        mediumTurquoise,
        paleTurquoise,
        aquaMarine,
        powderBlue,
        cadetBlue,
        steelBlue,
        cornFlowerBlue,
        deepSkyBlue,
        dodgerBlue,
        lightBlue,
        skyBlue,
        lightSkyBlue,
        midnightBlue,
        navy,
        darkBlue,
        mediumBlue,
        blue,
        royalBlue,
        blueViolet,
        indigo,
        darkSlateBlue,
        slateBlue,
        mediumSlateBlue,
        mediumPurple,
        darkMagenta,
        darkViolet,
        darkOrchid,
        mediumOrchid,
        purple,
        thistle,
        plum,
        violet,
        magetna,
        orchid,
        mediumVioletRed,
        paleVioletRed,
        deepPink,
        hotPink,
        lightPink,
        pink,
        antiqueWhite,
        beige,
        bisque,
        blanchedAlmond,
        wheat,
        cornSilk,
        lemonChiffon,
        lightGoldenRodYellow,
        lightYellow,
        saddleBrown,
        sienna,
        chocolate,
        peru,
        sandyBrown,
        burlyWood,
        tan,
        rosyBrown,
        moccasin,
        navajoWhite,
        peachPuff,
        mistyRose,
        lavenderBlush,
        linen,
        oldLace,
        papayaWhip,
        seaShell,
        mintCream,
        slateGray,
        lightSlateGray,
        lightSteelBlue,
        lavender,
        floralWhite,
        aliceBlue,
        ghostWhite,
        honeydew,
        ivory,
        azure,
        snow,
        black,
        gray,
        silver,
        lightGray,
        white

    }

    public static class EasyColor
    {

        public static Color SetColor(this QuickColors color)
        {

            switch (color)
            {

                case QuickColors.Clear:
                    return new Color32(0, 0, 0, 0);
                case QuickColors.White:
                    return new Color32(255, 255, 255, 1);
                case QuickColors.Black:
                    return new Color32(0, 0, 0, 1);
                case QuickColors.Grey:
                    return new Color32(128, 128, 128, 1);
                case QuickColors.Brown:
                    return new Color32(150, 75, 0, 1);
                case QuickColors.Red:
                    return new Color32(255, 0, 0, 1);
                case QuickColors.Yellow:
                    return new Color32(225, 255, 0, 1);
                case QuickColors.Blue:
                    return new Color32(0, 0, 255, 1);
                case QuickColors.Green:
                    return new Color32(0, 255, 0, 1);
                case QuickColors.Orange:
                    return new Color32(255, 165, 0, 1);
                case QuickColors.Violet:
                    return new Color32(143, 0, 255, 1);
                case QuickColors.Magenta:
                    return new Color32(255, 0, 255, 1);
                case QuickColors.Red_Orange:
                    return new Color32(255, 83, 73, 1);
                case QuickColors.Yellow_Orange:
                    return new Color32(255, 174, 66, 1);
                case QuickColors.Yellow_Green:
                    return new Color32(154, 205, 50, 1);
                case QuickColors.Blue_Green:
                    return new Color32(13, 152, 186, 1);
                case QuickColors.Blue_Violet:
                    return new Color32(138, 43, 226, 1);
                case QuickColors.Red_Violet:
                    return new Color32(199, 21, 133, 1);
                default:
                    return new Color32(255, 255, 255, 1);

                case QuickColors.maroon:
                    return new Color32(128, 0, 0, 1);
                case QuickColors.darkRed:
                    return new Color32(139, 0, 0, 1);
                case QuickColors.brown:
                    return new Color32(165, 42, 42, 1);
                case QuickColors.firebrick:
                    return new Color32(178, 34, 34, 1);
                case QuickColors.crimson:
                    return new Color32(220, 20, 60, 1);
                case QuickColors.red:
                    return new Color32(255, 0, 0, 1);
                case QuickColors.tomato:
                    return new Color32(255, 99, 71, 1);
                case QuickColors.coral:
                    return new Color32(255, 127, 80, 1);
                case QuickColors.indianRed:
                    return new Color32(205, 92, 92, 1);
                case QuickColors.lightCoral:
                    return new Color32(240, 128, 128, 1);
                case QuickColors.darkSalmon:
                    return new Color32(233, 150, 122, 1);
                case QuickColors.salmon:
                    return new Color32(250, 128, 114, 1);
                case QuickColors.lightSalmon:
                    return new Color32(255, 160, 122, 1);
                case QuickColors.orangeRed:
                    return new Color32(255, 69, 0, 1);
                case QuickColors.darkOrange:
                    return new Color32(255, 140, 0, 1);
                case QuickColors.orange:
                    return new Color32(255, 165, 0, 1);
                case QuickColors.gold:
                    return new Color32(255, 215, 0, 1);
                case QuickColors.darkGoldenRod:
                    return new Color32(184, 134, 11, 1);
                case QuickColors.goldenRod:
                    return new Color32(218, 165, 32, 1);
                case QuickColors.paleGoldenRod:
                    return new Color32(238, 232, 170, 1);
                case QuickColors.darkKhaki:
                    return new Color32(189, 183, 107, 1);
                case QuickColors.khaki:
                    return new Color32(240, 230, 140, 1);
                case QuickColors.olive:
                    return new Color32(128, 128, 0, 1);
                case QuickColors.yellow:
                    return new Color32(255, 255, 0, 1);
                case QuickColors.yellowGreen:
                    return new Color32(154, 205, 50, 1);
                case QuickColors.darkOliveGreen:
                    return new Color32(85, 107, 47, 1);
                case QuickColors.oliveDrab:
                    return new Color32(107, 142, 35, 1);
                case QuickColors.lawnGreen:
                    return new Color32(124, 252, 0, 1);
                case QuickColors.chartreuse:
                    return new Color32(127, 255, 0, 1);
                case QuickColors.greenYellow:
                    return new Color32(173, 255, 47, 1);
                case QuickColors.darkGreen:
                    return new Color32(0, 100, 0, 1);
                case QuickColors.green:
                    return new Color32(0, 128, 0, 1);
                case QuickColors.forestGreen:
                    return new Color32(34, 139, 34, 1);
                case QuickColors.lime:
                    return new Color32(0, 255, 0, 1);
                case QuickColors.limeGreen:
                    return new Color32(50, 205, 50, 1);
                case QuickColors.lightGreen:
                    return new Color32(144, 238, 144, 1);
                case QuickColors.paleGreen:
                    return new Color32(152, 251, 152, 1);
                case QuickColors.darkSeaGreen:
                    return new Color32(143, 188, 143, 1);
                case QuickColors.mediumSpringGreen:
                    return new Color32(0, 250, 154, 1);
                case QuickColors.springGreen:
                    return new Color32(0, 255, 127, 1);
                case QuickColors.seaGreen:
                    return new Color32(46, 139, 87, 1);
                case QuickColors.mediumAquaMarine:
                    return new Color32(102, 205, 170, 1);
                case QuickColors.mediumSeaGreen:
                    return new Color32(60, 179, 113, 1);
                case QuickColors.lightSeaGreen:
                    return new Color32(32, 178, 170, 1);
                case QuickColors.darkSlateGray:
                    return new Color32(47, 79, 79, 1);
                case QuickColors.teal:
                    return new Color32(0, 128, 128, 1);

            }

        }

    }

}

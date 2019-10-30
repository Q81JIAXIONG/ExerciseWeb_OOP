using System.Drawing;

namespace ExerciseWeb_OOP.App_Start
{
    /// <summary>
    /// 撲克牌
    /// </summary>
    abstract public class PlayingCard
    {
        /// <summary>
        /// 顏色
        /// </summary>
        public Color Color;
        /// <summary>
        /// 花色
        /// </summary>
        public string Pattern;
        /// <summary>
        /// 花色名稱
        /// </summary>
        public string Pattern_Name;
        /// <summary>
        /// 圖案
        /// </summary>
        public string FigurePath;
        /// <summary>
        /// 字
        /// </summary>
        public string Word;
        /// <summary>
        /// 鬼牌
        /// </summary>
        public bool Ghost = false;
        /// <summary>
        /// 牌數字的大小
        /// </summary>
        public int WordRank;
        /// <summary>
        ///  牌花色的大小
        /// </summary>
        public int PatternRank;

        /// <summary>
        /// 建構子:建構撲克牌(非鬼牌)
        /// </summary>
        /// <param name="_Color"></param>
        /// <param name="_Pattern"></param>
        /// <param name="_FigurePath"></param>
        /// <param name="_Word"></param>
        public PlayingCard(Color _Color, string _Pattern, string _FigurePath, string _Word)
        {
            Color = _Color;
            Pattern = _Pattern;
            FigurePath = _FigurePath;
            Word = _Word;
            Ghost = false;
        }
        /// <summary>
        /// 建構子:建構撲克牌(鬼牌)
        /// </summary>
        /// <param name="_Color"></param>
        /// <param name="_Ghost"></param>
        /// <param name="_FigurePath"></param>
        /// <param name="_Word"></param>
        public PlayingCard(Color _Color, bool _Ghost, string _FigurePath, string _Word)
        {
            Color = _Color;
            FigurePath = _FigurePath;
            Word = _Word;
            Ghost = _Ghost;
        }
    }
    /// <summary>
    /// 簡易撲克牌
    /// </summary>
    public class SimplePlayingCard : PlayingCard
    {
        /// <summary>
        /// 建構子:建構撲克牌(非鬼牌)
        /// </summary>
        /// <param name="_Color"></param>
        /// <param name="_Pattern"></param>
        /// <param name="_FigurePath"></param>
        /// <param name="_Word"></param>
        /// <param name="_PatternName"></param>
        public SimplePlayingCard(Color _Color, string _Pattern, string _FigurePath, string _Word,string _PatternName) : base(_Color, _Pattern, _FigurePath, _Word)
        {
            Pattern_Name = _PatternName;
        }
        /// <summary>
        /// 建構子:建構撲克牌(鬼牌)
        /// </summary>
        /// <param name="_Color"></param>
        /// <param name="_Ghost"></param>
        /// <param name="_FigurePath"></param>
        /// <param name="_Word"></param>
        public SimplePlayingCard(Color _Color, bool _Ghost, string _FigurePath, string _Word) : base(_Color, _Ghost, _FigurePath, _Word)
        {
        }
    }
    
}
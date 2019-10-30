using System;

namespace ExerciseWeb_OOP.App_Start
{
    /// <summary>
    /// 紙牌比大小
    /// </summary>
    abstract public class SpecificSize
    {
        public SpecificSize(PlayingCardGroup _PlayingCardGroup) { }
        /// <summary>
        /// 兩張牌比大小
        /// </summary>
        /// <returns></returns>
        abstract public string ComparisonTwoCards(PlayingCard _Card1, PlayingCard _Card2);
    }
    /// <summary>
    /// 大老2比大小
    /// </summary>
    public class BigTwoSpecificSize : SpecificSize
    {
        /// <summary>
        /// 大老2比大小
        /// </summary>
        /// <param name="_PlayingCardGroup"></param>
        public BigTwoSpecificSize(PlayingCardGroup _PlayingCardGroup) : base(_PlayingCardGroup)
        {
            GiveRank(_PlayingCardGroup);
        }
        /// <summary>
        /// 給牌大小排名
        /// </summary>
        /// <param name="_PlayingCardGroup"></param>
        private void GiveRank(PlayingCardGroup _PlayingCardGroup)
        {
            for (int i = 0; i < _PlayingCardGroup.UnflippedsCount;)
            {
                PlayingCard P = _PlayingCardGroup.PumpingUnflop(0);
                if (P.Word == "2")
                    P.WordRank = 13;
                else if (P.Word == "A")
                    P.WordRank = 12;
                else if (P.Word == "K")
                    P.WordRank = 11;
                else if (P.Word == "Q")
                    P.WordRank = 10;
                else if (P.Word == "J")
                    P.WordRank = 9;
                else if (P.Ghost == false)
                    P.WordRank = Convert.ToInt32(P.Word) - 2;

                if (P.Pattern_Name == "黑桃")
                    P.PatternRank = 4;
                else if (P.Pattern_Name == "紅心")
                    P.PatternRank = 3;
                else if (P.Pattern_Name == "方塊")
                    P.PatternRank = 2;
                else if (P.Pattern_Name == "梅花")
                    P.PatternRank = 1;
            }
            for (int i = 0; i < _PlayingCardGroup.FlippedCardCount;)
            {
                _PlayingCardGroup.UnPumpingUnflop(0);
            }
        }

        /// <summary>
        /// 比較兩張牌
        /// </summary>
        /// <param name="_Card1"></param>
        /// <param name="_Card2"></param>
        /// <returns></returns>
        public override string ComparisonTwoCards(PlayingCard _Card1, PlayingCard _Card2)
        {
            return ComparisonTwoCardsWord(_Card1, _Card2);
        }
        /// <summary>
        /// 比較數字
        /// </summary>
        /// <param name="_PlayingCardArrat"></param>
        /// <returns></returns>
        private string ComparisonTwoCardsWord(PlayingCard _Card1, PlayingCard _Card2)
        {
            if (_Card1 != null)
            {
                if (_Card1.Word == _Card2.Word)
                    return ComparisonTwoCardsPattern(_Card1, _Card2);
                else
                {
                    if (_Card1.WordRank > _Card2.WordRank)
                        return "＞";
                    else
                        return "＜";
                }
            }
            else
                return "＝";
        }
        /// <summary>
        /// 比較花色
        /// </summary>
        /// <param name="_PlayingCardArrat"></param>
        /// <returns></returns>
        private string ComparisonTwoCardsPattern(PlayingCard _Card1, PlayingCard _Card2)
        {
            if (_Card1.PatternRank > _Card2.PatternRank)
                return "＞";
            else
                return "＜";
        }
    }
}
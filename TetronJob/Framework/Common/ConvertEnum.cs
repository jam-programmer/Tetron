using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common
{
    public static class ConvertEnum
    {
        public static ConditionEnum ConvertCondition(ConditionViewMode condition)
        {
            switch (condition)
            {
                case ConditionViewMode.منتشرشد:
                    return ConditionEnum.Confirmation;
                case ConditionViewMode.درانتظارتائید:
                    return ConditionEnum.Waiting;
                case ConditionViewMode.ردشد:
                    return ConditionEnum.NonApproval;
                default:
                    return ConditionEnum.Waiting;
            }
        }
        public static ConditionViewMode ConvertConditionViewModel(ConditionEnum condition)
        {
            switch (condition)
            {
                case ConditionEnum.Confirmation:
                    return ConditionViewMode.منتشرشد;
                case ConditionEnum.NonApproval:
                    return ConditionViewMode.ردشد;
                case ConditionEnum.Waiting:
                    return ConditionViewMode.درانتظارتائید;
                default:
                    return ConditionViewMode.درانتظارتائید;
            }
        }
        public static PositionEnum ConvertPosition(PositionSliderEnum position)
        {
            switch (position)
            {
                case PositionSliderEnum.خانه:
                    return PositionEnum.Home;
                case PositionSliderEnum.آگهی:
                    return PositionEnum.Advertising;
                case PositionSliderEnum.درباره:
                    return PositionEnum.About; 
                case PositionSliderEnum.دسته:
                    return PositionEnum.Category;

                default:
                    return PositionEnum.Home;
            }
        }
        public static PositionSliderEnum ConvertPositionSlider(PositionEnum? position)
        {
            switch (position)
            {
                case PositionEnum.Home:
                    return PositionSliderEnum.خانه;
                case PositionEnum.Category:
                    return PositionSliderEnum.دسته;
                case PositionEnum.About:
                    return PositionSliderEnum.درباره;
                case PositionEnum.Advertising:
                    return PositionSliderEnum.آگهی;
            
                default:
                    return PositionSliderEnum.خانه;
            }
        }
    }
}

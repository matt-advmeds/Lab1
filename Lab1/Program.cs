using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program  // 產生SQL 將mphr部分版本問卷資料 改為 使用公版 
    {

        class Item
        {
            public string SurveyAnswerGID { get; set; }
            public string AnswerText { get; set; }
            public string QuestionText { get; set; }
        }

        static void Main(string[] args)
        {

            //string SurveyGID = "9B5A77FF-91F9-4ABD-83F2-2D45C1248FEC",SurveyName = "ADL日常生活動量表"; 
            //string SurveyGID = "3CFD625F-4A44-47E4-BB2C-2D759F2088B1",SurveyName = "AD-8 早期失智症篩檢量表"; 
            //string SurveyGID = "92C8C000-5F8D-4EC8-95EA-39822C8595D2",SurveyName = "尼古丁成癮度"; 
            //string SurveyGID = "33DEDE59-8F9D-4FBE-A72B-8F3EF6A73D54", SurveyName = "高血壓患者健康飲食評估";
            string SurveyGID = "1DDF62F3-F390-43B9-92E5-BC54E015B83F", SurveyName = "工具性日常生活活動能力量表（IADL）";  

            string sql = "";

            //生成 SurveryResult SQL
            sql += produceSQL_surveyresult(SurveyGID, SurveyName);


            //生成 SurveryResultItem SQL
            List<Item> Survey = getList(SurveyGID);
            sql += "--update surveyresultitem \r\n";
            sql += "\r\n";
            foreach (Item item in Survey)
            {
                sql += produceSQL_surveyresultitem(SurveyGID, item.SurveyAnswerGID, item.QuestionText, item.AnswerText);
                sql += "\r\n";
            }

            //生成 移除 SQL
            sql += produceSQL_delete(SurveyGID, SurveyName);

            Console.Write(sql);
            Console.ReadLine();

        }


        #region getList
        private static List<Item> getList(string SurveyGID)
        {
            //new Item { QuestionText = "", SurveyAnswerGID = "", AnswerText = "" },


            List<Item> Survey = new List<Item>();
            switch (SurveyGID)
            {
                case "9B5A77FF-91F9-4ABD-83F2-2D45C1248FEC": //ADL日常生活動量表
                    Survey = new List<Item>
                    {
                        new Item{QuestionText="上下樓梯",SurveyAnswerGID = "1FB8279A-2EC5-4FCE-9DC6-025EB4159F5F",AnswerText="可自行上下樓梯 (允許抓扶手、用拐杖 )。"},
                        new Item{QuestionText="上下樓梯",SurveyAnswerGID = "4B670D46-2AF6-48DF-B34E-9C1DBB6EC1F9",AnswerText="無法上下樓梯。"},
                        new Item{QuestionText="上下樓梯",SurveyAnswerGID = "99C90E07-218E-43C7-86DB-856F83DD965C",AnswerText="需稍微協助或口頭指導"},

                        new Item{QuestionText="如廁",SurveyAnswerGID = "3496C133-4F5F-4133-AD02-48E08FA9C28C",AnswerText="可自行進出廁所，不會弄髒衣服並能穿好衣服"},
                        new Item{QuestionText="如廁",SurveyAnswerGID = "B5F7D962-BDBA-4CD7-9BBA-E7869CE23477",AnswerText="需別人協助。"},
                        new Item{QuestionText="如廁",SurveyAnswerGID = "81882CE3-51D0-47B7-81C7-8A94FE80838E",AnswerText="需幫忙保持姿勢的平衡，整理以物或使用衛生紙，使用便盆者，可自行取放便盆但須仰賴他人清理。"},

                        new Item{QuestionText="步行",SurveyAnswerGID = "46523240-BB8C-4079-A635-920EC5526B20",AnswerText="使用或不輔具皆可獨立行走 50 公尺以上。"},
                        new Item{QuestionText="步行",SurveyAnswerGID = "359C61DE-5E03-4D86-A124-536D35FE8368",AnswerText="需別人協助推輪椅。"},
                        new Item{QuestionText="步行",SurveyAnswerGID = "557FF2B9-8C83-49E1-AB17-A876DD588E77",AnswerText="需要稍微扶持或口頭指導方可行走 50 公尺以上。"},
                        new Item{QuestionText="步行",SurveyAnswerGID = "DA82D79E-0AD5-4BA2-8F86-6DEE594B7C78",AnswerText="雖無法行走，但可獨自操縱輪椅（包括轉彎、進門及接近桌子、 床沿 )並可推行輪椅 50 公尺以上。"},

                        new Item{QuestionText="洗澡",SurveyAnswerGID = "49095A32-B4B5-4CB0-A456-36E55B47A584",AnswerText="可獨立完成，不需別人在旁 (不論是盆浴 或淋)。"},
                        new Item{QuestionText="洗澡",SurveyAnswerGID = "524DF7AF-0C41-4C1C-9DB4-DE73BF5153F2",AnswerText="需別人協助。"},

                        new Item { QuestionText = "穿脫衣服", SurveyAnswerGID = "E9FEE383-5652-4DCF-BBFC-163BA1036E09", AnswerText = "可自行穿脫衣服、褲子鞋及輔具等。" },
                        new Item { QuestionText = "穿脫衣服", SurveyAnswerGID = "2D37EA87-70EF-4E1A-B425-71177DF36515", AnswerText = "在別人協助下，可自行完成一半的動作。" },
                        new Item { QuestionText = "穿脫衣服", SurveyAnswerGID = "CB5F7A52-3E00-40C4-B219-30D83066C6C4", AnswerText = "需別人協助。" },

                        new Item { QuestionText = "個人衛生", SurveyAnswerGID = "66255894-D1AB-475D-98AA-9F251FE55601", AnswerText = "可獨立完成洗臉、手刷牙及梳頭髮。" },
                        new Item { QuestionText = "個人衛生", SurveyAnswerGID = "9A789257-2454-4994-9B2C-D11B7D8F97CB", AnswerText = "需別人協助。" },

                        new Item { QuestionText = "排尿控制", SurveyAnswerGID = "95ABEAD3-789F-44F5-A32B-9B0BD267B726", AnswerText = "日夜皆不會尿失禁，或可自行使用並清理套。" },
                        new Item { QuestionText = "排尿控制", SurveyAnswerGID = "7B8291EA-8FC1-404E-8B71-9A61F1F9F962", AnswerText = "完全依賴。" },
                        new Item { QuestionText = "排尿控制", SurveyAnswerGID = "99C3517B-5051-4859-B1A1-5A96F9909250", AnswerText = "偶而會尿失禁  (每週不超過一次)或尿急  (無法等待便盆或及時敢到廁所)或需別人幫忙處理尿套。" },

                        new Item { QuestionText = "排便控制", SurveyAnswerGID = "314E2CE8-ADF1-4D23-91F1-E20E865DCD1D", AnswerText = "不會失禁，並可自行使用塞劑。" },
                        new Item { QuestionText = "排便控制", SurveyAnswerGID = "D357D3C5-0FBB-4C17-9CD0-D5B13D133C8E", AnswerText = "完全依賴。" },
                        new Item { QuestionText = "排便控制", SurveyAnswerGID = "EFD70C9A-8F14-40BB-B52D-8322750B978E", AnswerText = "偶而會失禁 (每週不超過一次 )或使用塞劑時需別人協助。" },

                        new Item { QuestionText = "移位(輪椅與床位間的移動)", SurveyAnswerGID = "39519CFA-101B-45D1-A778-AF8FB5F4C99B", AnswerText = "可自行從床上坐起來，但移位時仍需要人幫忙。" },
                        new Item { QuestionText = "移位(輪椅與床位間的移動)", SurveyAnswerGID = "DDBC4B35-61AF-43BA-8883-25E1080BF234", AnswerText = "可獨立完成，包括輪椅的煞車及移開腳踏板。" },
                        new Item { QuestionText = "移位(輪椅與床位間的移動)", SurveyAnswerGID = "44CEB02C-7AF3-4148-820D-67514BD1426B", AnswerText = "需別人協助可坐起來或要兩幫忙方移位。" },
                        new Item { QuestionText = "移位(輪椅與床位間的移動)", SurveyAnswerGID = "27556C12-7329-4BC1-B426-4A583E41A5F8", AnswerText = "需要稍微的協助 (例如：予以輕扶保持平衡  )或需要口頭指導。" },

                        new Item { QuestionText = "進食", SurveyAnswerGID = "C14ACB47-027F-4A61-9AAA-AEC164B2EC6A", AnswerText = "自己在合理時間內（約 10 秒鐘吃一口飯）可用筷子取食眼前的 秒鐘吃一口飯）可用筷子取食眼前的 食物，若需使用進輔具時應會自行穿脫。" },
                        new Item { QuestionText = "進食", SurveyAnswerGID = "B50A228F-78E2-4D7A-8F90-480E3023BED6", AnswerText = "無法自行取食或耗費時間過長。" },
                        new Item { QuestionText = "進食", SurveyAnswerGID = "FA89D6FD-63E3-4128-A97F-BA52D63594BB", AnswerText = "需別人幫忙穿脫輔具或只會用湯匙進食。" },
                    };
                    break;
                case "3CFD625F-4A44-47E4-BB2C-2D759F2088B1": //AD-8 早期失智症篩檢量表
                    Survey = new List<Item>
                    {
                        new Item { QuestionText = "在學習如何使用工具設備和小器具上有困難，例如:電視，音響，冷氣", SurveyAnswerGID = "BCBEFCC4-451D-4F5B-9DCA-EF68E7FF7183", AnswerText = "不知道" },
                        new Item { QuestionText = "在學習如何使用工具設備和小器具上有困難，例如:電視，音響，冷氣", SurveyAnswerGID = "64A2DCF7-7F06-4258-9CF0-E57C240178DC", AnswerText = "不是， 沒有改變" },
                        new Item { QuestionText = "在學習如何使用工具設備和小器具上有困難，例如:電視，音響，冷氣", SurveyAnswerGID = "11EC060C-F3B9-44BF-BB12-316544566633", AnswerText = "是， 有改變" },

                        new Item { QuestionText = "有持續的思考和記憶方面的問題", SurveyAnswerGID = "EACC152C-47BE-47FD-A630-47CDD9C74DCE", AnswerText = "不知道" },
                        new Item { QuestionText = "有持續的思考和記憶方面的問題", SurveyAnswerGID = "562723FB-24CC-4509-B46D-8F15A7EF70CD", AnswerText = "不是， 沒有改變" },
                        new Item { QuestionText = "有持續的思考和記憶方面的問題", SurveyAnswerGID = "236C0990-2EE9-481F-AAA5-23A74A63D277", AnswerText = "是， 有改變" },

                        new Item { QuestionText = "判斷力上的困難:例如落入圈套，財務上不好的決定，買了對受禮者不合宜的禮物", SurveyAnswerGID = "8BC48CBF-1C64-47B9-B857-EADB7A52FDCB", AnswerText = "不知道" },
                        new Item { QuestionText = "判斷力上的困難:例如落入圈套，財務上不好的決定，買了對受禮者不合宜的禮物", SurveyAnswerGID = "A8B88019-0CDF-4CB0-885A-825AFC4661E9", AnswerText = "不是， 沒有改變" },
                        new Item { QuestionText = "判斷力上的困難:例如落入圈套，財務上不好的決定，買了對受禮者不合宜的禮物", SurveyAnswerGID = "01EE0E87-0C64-4AD5-A53C-A8EA17DC9916", AnswerText = "是， 有改變" },

                        new Item { QuestionText = "忘記正確的年份和月份", SurveyAnswerGID = "79AB87C6-F622-4F1A-B593-5AF647512145", AnswerText = "不知道" },
                        new Item { QuestionText = "忘記正確的年份和月份", SurveyAnswerGID = "E92EBC0E-AB3A-4CB0-ACE7-660ACF54618D", AnswerText = "不是， 沒有改變" },
                        new Item { QuestionText = "忘記正確的年份和月份", SurveyAnswerGID = "925C58DD-A165-4FCE-A467-AE9F5629CBAE", AnswerText = "是， 有改變" },

                        new Item { QuestionText = "重複相同的問題，故事和陳述", SurveyAnswerGID = "30C7DE0A-7073-4617-BD0E-7E9E3E1DE250", AnswerText = "不知道" },
                        new Item { QuestionText = "重複相同的問題，故事和陳述", SurveyAnswerGID = "47F054E2-0BC8-4830-A968-C5751C351048", AnswerText = "不是， 沒有改變" },
                        new Item { QuestionText = "重複相同的問題，故事和陳述", SurveyAnswerGID = "8A3D0A28-C59F-46D9-91EF-9B7EAF3125F3", AnswerText = "是， 有改變" },

                        new Item { QuestionText = "記住約會的時間有困難", SurveyAnswerGID = "6FF80E21-0ADB-4194-BF8E-C49A304651DB", AnswerText = "不知道" },
                        new Item { QuestionText = "記住約會的時間有困難", SurveyAnswerGID = "60BF0E3F-AAD4-4C3E-A5FD-A316052A281C", AnswerText = "不是， 沒有改變" },
                        new Item { QuestionText = "記住約會的時間有困難", SurveyAnswerGID = "BF7ED28D-29D7-4976-81F4-915C4104C292", AnswerText = "是， 有改變" },

                        new Item { QuestionText = "處理複雜的財務上有困難", SurveyAnswerGID = "C131A319-54E2-48E5-A095-7D660AFACFE4", AnswerText = "不知道" },
                        new Item { QuestionText = "處理複雜的財務上有困難", SurveyAnswerGID = "0213275F-05AF-4615-8654-528A6A8F2485", AnswerText = "不是， 沒有改變" },
                        new Item { QuestionText = "處理複雜的財務上有困難", SurveyAnswerGID = "1ABB37C2-621C-4256-AD8B-B4748598D5E8", AnswerText = "是， 有改變" },

                        new Item { QuestionText = "對活動和嗜好的興趣降低", SurveyAnswerGID = "1EFF8640-EC4E-445B-8D84-520B6986DA8A", AnswerText = "不知道" },
                        new Item { QuestionText = "對活動和嗜好的興趣降低", SurveyAnswerGID = "CC78FED6-043C-449E-B677-E76A393E2877", AnswerText = "不是， 沒有改變" },
                        new Item { QuestionText = "對活動和嗜好的興趣降低", SurveyAnswerGID = "08A23EE9-72D3-40C3-993F-7B7D3B41F902", AnswerText = "是， 有改變" },
                    };
                    break;
                case "92C8C000-5F8D-4EC8-95EA-39822C8595D2": //尼古丁成癮度
                    Survey = new List<Item>
                    {
                        new Item { QuestionText = "一天最多抽幾支菸?", SurveyAnswerGID = "D43A1EF9-0EE2-4FA9-8623-D911921D08CB", AnswerText = "10支或更少" },
                        new Item { QuestionText = "一天最多抽幾支菸?", SurveyAnswerGID = "849CEC43-7CB4-4A32-9454-7F2556800FAE", AnswerText = "11~20支" },
                        new Item { QuestionText = "一天最多抽幾支菸?", SurveyAnswerGID = "6EE91C49-977F-407F-BE83-7EBC4FCB8EDA", AnswerText = "21~30支" },
                        new Item { QuestionText = "一天最多抽幾支菸?", SurveyAnswerGID = "4A14B2DD-F2B2-405E-A33B-C251C8C3D4F6", AnswerText = "31支以上" },

                        new Item { QuestionText = "在禁菸區不能吸菸會難以忍受嗎?", SurveyAnswerGID = "9622B0FB-CDE6-4F9E-A5AA-810D2126D660", AnswerText = "否" },
                        new Item { QuestionText = "在禁菸區不能吸菸會難以忍受嗎?", SurveyAnswerGID = "22C12F67-9448-46EA-A219-A8268E98A5EF", AnswerText = "是" },

                        new Item { QuestionText = "那根菸是你最難放棄不抽?", SurveyAnswerGID = "F799AE12-F39C-4C2E-90A0-B823403724D8", AnswerText = "早上第一支菸" },
                        new Item { QuestionText = "那根菸是你最難放棄不抽?", SurveyAnswerGID = "39AE8171-09C9-4A70-BE81-A2C884895A2C", AnswerText = "其他" },

                        new Item { QuestionText = "起床後多久抽第一支菸?", SurveyAnswerGID = "54505A18-3624-4855-B339-7B992FA319FC", AnswerText = "31~60分鐘" },
                        new Item { QuestionText = "起床後多久抽第一支菸?", SurveyAnswerGID = "DBE7D702-15E5-4B1E-996A-2B5C5006CC9C", AnswerText = "5~30分鐘" },
                        new Item { QuestionText = "起床後多久抽第一支菸?", SurveyAnswerGID = "BA651775-7D91-4A99-95AA-A5B43D59F25D", AnswerText = "5分鐘以內" },
                        new Item { QuestionText = "起床後多久抽第一支菸?", SurveyAnswerGID = "41308146-28A9-4818-89E8-D9CE66B5646E", AnswerText = "60分鐘以上" },

                        new Item { QuestionText = "起床後幾小時內是一天中抽最多菸的時候?", SurveyAnswerGID = "5499BA51-DB58-4658-97FE-8F1642BDD9FD", AnswerText = "否" },
                        new Item { QuestionText = "起床後幾小時內是一天中抽最多菸的時候?", SurveyAnswerGID = "CEAF4E52-0189-4DBB-89AC-98BEAE243DED", AnswerText = "是" },

                        new Item { QuestionText = "當嚴重生病時，幾乎每天臥病在床還抽菸嗎?", SurveyAnswerGID = "D282E1BA-1A75-4CCC-8E52-BF8AE2591AD2", AnswerText = "否" },
                        new Item { QuestionText = "當嚴重生病時，幾乎每天臥病在床還抽菸嗎?", SurveyAnswerGID = "A3010622-DF45-4B88-84FA-C81453ABD21E", AnswerText = "是" },
                    };
                    break;
                case "33DEDE59-8F9D-4FBE-A72B-8F3EF6A73D54": //高血壓患者健康飲食評估
                    Survey = new List<Item>
                    {
                        new Item { QuestionText = "我用餐很少加調味料", SurveyAnswerGID = "E54E457D-69DC-451B-B336-56FC19E9AABE", AnswerText = "否" },
                        new Item { QuestionText = "我用餐很少加調味料", SurveyAnswerGID = "79FE95C8-A21A-45AB-977D-E68292D0C278", AnswerText = "是" },

                        new Item { QuestionText = "我每餐只吃到約7~8分飽", SurveyAnswerGID = "C554D1BD-B178-455A-842D-DD87D6F7C342", AnswerText = "否" },
                        new Item { QuestionText = "我每餐只吃到約7~8分飽", SurveyAnswerGID = "9848270D-2E83-4B18-BC10-933528162DAC", AnswerText = "是" },

                        new Item { QuestionText = "我很少吃加工食品(火腿,貢丸,罐頭)", SurveyAnswerGID = "74BAA1CD-51E2-4FF1-821F-B9FB4AA6CA94", AnswerText = "否" },
                        new Item { QuestionText = "我很少吃加工食品(火腿,貢丸,罐頭)", SurveyAnswerGID = "F2382B7B-794E-47F1-834F-1C495322473A", AnswerText = "是" },

                        new Item { QuestionText = "我很少吃油炸食物", SurveyAnswerGID = "DD894A28-96C0-4299-9E1B-35B23FB9D06E", AnswerText = "否" },
                        new Item { QuestionText = "我很少吃油炸食物", SurveyAnswerGID = "4EFCC025-0762-4ABB-958B-3453827B8C27", AnswerText = "是" },

                        new Item { QuestionText = "我很少吃泡麵", SurveyAnswerGID = "E5FEF9D5-DED3-4F82-8BE0-5695ED37905E", AnswerText = "否" },
                        new Item { QuestionText = "我很少吃泡麵", SurveyAnswerGID = "561FB290-0F0F-443D-B1B4-FB4C6AC6C2B4", AnswerText = "是" },

                        new Item { QuestionText = "我很少吃零食,蛋糕等食品", SurveyAnswerGID = "4AD1BF51-BD61-4195-9885-E0BBCAC071E9", AnswerText = "否" },
                        new Item { QuestionText = "我很少吃零食,蛋糕等食品", SurveyAnswerGID = "E40D2A65-F271-472C-90A3-072C63730CEA", AnswerText = "是" },

                        new Item { QuestionText = "我經常吃五穀米,糙米,雜糧麵包等天然食物", SurveyAnswerGID = "1D68B89B-F1AC-4C0D-8C85-C092A7319F1D", AnswerText = "否" },
                        new Item { QuestionText = "我經常吃五穀米,糙米,雜糧麵包等天然食物", SurveyAnswerGID = "848109C8-A6F6-4F32-9479-5888CDFE100C", AnswerText = "是" },

                        new Item { QuestionText = "我經常吃豆腐之類的黃豆食品或豆類料理", SurveyAnswerGID = "B2FB58C6-EFD1-4B89-87F0-B7C62DFEA4D6", AnswerText = "否" },
                        new Item { QuestionText = "我經常吃豆腐之類的黃豆食品或豆類料理", SurveyAnswerGID = "D89F821D-7530-4C50-B232-0229D1039653", AnswerText = "是" },

                        new Item { QuestionText = "我經常每天吃到四碟蔬菜", SurveyAnswerGID = "DEC665E7-A282-47C3-ADE0-88E424A757AA", AnswerText = "否" },
                        new Item { QuestionText = "我經常每天吃到四碟蔬菜", SurveyAnswerGID = "DBC9F356-A3C0-40E1-AC42-882573AFED50", AnswerText = "是" },

                        new Item { QuestionText = "我經常每天都吃四份水果", SurveyAnswerGID = "3A0E994A-E715-4275-B878-A14964C78FF5", AnswerText = "否" },
                        new Item { QuestionText = "我經常每天都吃四份水果", SurveyAnswerGID = "E15164E8-94A8-45AE-BE32-44C24CED0E7C", AnswerText = "是" },
                    };
                    break;
                case "1DDF62F3-F390-43B9-92E5-BC54E015B83F": //工具性日常生活活動能力量表（IADL）
                    Survey = new List<Item>
                    {
                        new Item { QuestionText = "上街購物", SurveyAnswerGID = "51499E30-662C-40E6-ABD4-AF81DD76DE6F", AnswerText = "不適用" },
                        new Item { QuestionText = "上街購物", SurveyAnswerGID = "0FED06C7-B6D2-48F0-8D3C-809B891CE69C", AnswerText = "完全不會上街購物" },
                        new Item { QuestionText = "上街購物", SurveyAnswerGID = "16F004A3-8CF3-480B-A1AC-F9428A49DAAC", AnswerText = "每一次上街購物都需要有人陪" },
                        new Item { QuestionText = "上街購物", SurveyAnswerGID = "8724E985-9753-4AB3-B54C-52076AA32CFB", AnswerText = "獨立完成所有購物需求" },
                        new Item { QuestionText = "上街購物", SurveyAnswerGID = "2D5DF21B-7AC8-416B-B6FA-F185187EAF07", AnswerText = "獨立購買日常生活用品" },

                        new Item { QuestionText = "外出活動", SurveyAnswerGID = "EA41395B-BDC2-4E29-9302-1D2E6DC64981", AnswerText = "不適用" },
                        new Item { QuestionText = "外出活動", SurveyAnswerGID = "89ED6BFA-814B-4727-9A42-95CB57FCD6F2", AnswerText = "完全不能出門" },
                        new Item { QuestionText = "外出活動", SurveyAnswerGID = "505BA356-EA2C-44C5-925F-B9361155EC85", AnswerText = "能夠自己開車、騎車" },
                        new Item { QuestionText = "外出活動", SurveyAnswerGID = "35123B2E-0C3D-43DE-8CC9-64D5F330518C", AnswerText = "能夠自己搭乘大眾運輸工具" },
                        new Item { QuestionText = "外出活動", SurveyAnswerGID = "37569094-4E31-42BE-91FA-87C3D1DED05C", AnswerText = "能夠自己搭乘計程車但不會搭乘大眾運輸工具" },
                        new Item { QuestionText = "外出活動", SurveyAnswerGID = "CF9E7AB1-616A-47CA-AE66-EF32F5EB0D85", AnswerText = "當有人陪同可搭計程車或大眾運輸工具" },

                        new Item { QuestionText = "使用電話的能力", SurveyAnswerGID = "0D53A17E-4249-4C65-8359-59E9220673FD", AnswerText = "不適用" },
                        new Item { QuestionText = "使用電話的能力", SurveyAnswerGID = "909E6246-D018-4A93-8B86-687545C3AC30", AnswerText = "完全不會使用電話" },
                        new Item { QuestionText = "使用電話的能力", SurveyAnswerGID = "550ABB17-FA44-434B-B517-6F38A1055076", AnswerText = "僅可撥熟悉的電話號碼" },
                        new Item { QuestionText = "使用電話的能力", SurveyAnswerGID = "DBE01510-450E-49D0-839E-30EBF0E9AD52", AnswerText = "僅會接電話，不會撥電話" },
                        new Item { QuestionText = "使用電話的能力", SurveyAnswerGID = "2873B925-4DB2-49BC-91CC-5761E4CFFC80", AnswerText = "獨立使用電話，含查電話簿、撥號等" },

                        new Item { QuestionText = "服用藥物", SurveyAnswerGID = "61B5CFC3-072D-4DCB-BE87-A1A212FE8DE4", AnswerText = "不適用" },
                        new Item { QuestionText = "服用藥物", SurveyAnswerGID = "4F4CA39D-3732-44B5-BAF3-763F335CCBDA", AnswerText = "如果事先準備好服用的藥物份量，可自行服用" },
                        new Item { QuestionText = "服用藥物", SurveyAnswerGID = "5DAA2229-1230-4F14-A6B6-AFC7E11C6EC1", AnswerText = "能自己負責在正確的時間用正確的藥物" },
                        new Item { QuestionText = "服用藥物", SurveyAnswerGID = "572EA62B-29DC-4ADF-97BB-A4E8DCD82585", AnswerText = "需要提醒或少許協助" },

                        new Item { QuestionText = "洗衣服", SurveyAnswerGID = "397AE96D-2E7D-4974-A7D5-EC559257AD1F", AnswerText = "不適用" },
                        new Item { QuestionText = "洗衣服", SurveyAnswerGID = "04016665-19D9-4729-B095-73A5E606DCA7", AnswerText = "只清洗小件衣物" },
                        new Item { QuestionText = "洗衣服", SurveyAnswerGID = "D940EDF0-65DC-42F1-B2E6-389FAC4F1BB7", AnswerText = "自己清洗所有衣物" },
                        new Item { QuestionText = "洗衣服", SurveyAnswerGID = "1EF6BE3B-952B-49AA-A9CF-255FE5576749", AnswerText = "完全依賴他人" },

                        new Item { QuestionText = "食物烹調", SurveyAnswerGID = "4DBA3F37-5F2F-434A-9FA5-1045EE3ED55C", AnswerText = "不適用" },
                        new Item { QuestionText = "食物烹調", SurveyAnswerGID = "5AF217EA-F08A-45AB-851C-9BEE88DD7226", AnswerText = "如果準備好一切佐料，會做一頓適當的飯菜" },
                        new Item { QuestionText = "食物烹調", SurveyAnswerGID = "4311CF90-4C73-49B7-A3C3-80F3179BEA05", AnswerText = "能獨立計畫、烹煮和擺設一頓適當的飯菜" },
                        new Item { QuestionText = "食物烹調", SurveyAnswerGID = "140AC8C3-9FA6-435E-A9E3-B85475EA4CD9", AnswerText = "會將已做好的飯菜加熱" },
                        new Item { QuestionText = "食物烹調", SurveyAnswerGID = "4B7AEC67-8C03-4B46-80FE-2C7ABE688732", AnswerText = "需要別人把飯菜煮好、擺好" },

                        new Item { QuestionText = "家務維持", SurveyAnswerGID = "68790486-86AE-4421-B7C8-42E8AD00B1EE", AnswerText = "不適用" },
                        new Item { QuestionText = "家務維持", SurveyAnswerGID = "585EEA9E-E612-483B-B160-8E03BA395742", AnswerText = "完全不會做家事" },
                        new Item { QuestionText = "家務維持", SurveyAnswerGID = "A61F6B03-04BF-43B8-80F1-DE305C6EA6CF", AnswerText = "所有的家事都需要別人協助" },
                        new Item { QuestionText = "家務維持", SurveyAnswerGID = "09F9D6BD-5D4F-4AF9-972F-CC548256DF33", AnswerText = "能做家事，但不能達到可被接受的整潔程度" },
                        new Item { QuestionText = "家務維持", SurveyAnswerGID = "E39565E2-259F-4AD2-A0E5-D0BEC7FBF013", AnswerText = "能做較繁重的家事或需偶爾家事協助（如搬動沙發、擦地板、洗窗戶）" },
                        new Item { QuestionText = "家務維持", SurveyAnswerGID = "DB7CA9EF-CAA5-404C-9A80-F88547228194", AnswerText = "能做較簡單的家事，如洗碗、鋪床、疊被" },

                        new Item { QuestionText = "處理財務能力", SurveyAnswerGID = "312E8420-EB1E-458D-9AD5-22EE3344EB80", AnswerText = "不適用" },
                        new Item { QuestionText = "處理財務能力", SurveyAnswerGID = "FA901FFB-E3C5-4D46-8C75-D5AECD659F6D", AnswerText = "可以處理日常的購買，但需要別人協助與銀行往來或大宗 買賣" },
                        new Item { QuestionText = "處理財務能力", SurveyAnswerGID = "2464B74B-0D76-4D5A-96AC-916F35F908E8", AnswerText = "可以獨立處理財務" },
                    };
                    break;
            }
            

            return Survey;
        }

        #endregion


        #region produceSQL
        private static string produceSQL_surveyresult(string SurveyGID, string SurveyName)
        {
            string sql = "--update surveyresult \r\n";
            sql += "\r\n";
            sql += "update SurveyResult set SurveyGID = '"+ SurveyGID + "' \r\n";
            sql += "from surveyresult a left join Survey b on a.SurveyGID=b.GID where b.SurveyName like '%" + SurveyName + "%' \r\n";
            sql += "\r\n";

            return sql;
        }

        private static string produceSQL_surveyresultitem(string SurveyGID, string SurveyAnswerGID, string QuestionText,string AnswerText)
        {
            string sql = "update SurveyResultItem set SurveyAnswerGID = '" + SurveyAnswerGID + "' \r\n";
            sql += "from surveyresult a left join SurveyResultItem b on a.GID=b.SurveyResultGID \r\n";
            sql += "left join SurveyAnswer c on b.SurveyAnswerGID=c.GID left join SurveyQuestion d on c.SurveyQuestionGID=d.GID \r\n";
            sql += "where a.SurveyGID='" + SurveyGID + "' and c.AnswerText='"+ AnswerText + "' and d.QuestionText='" + QuestionText + "' \r\n";

            return sql;
        }

        private static string produceSQL_delete(string SurveyGID, string SurveyName)
        {
            string sql = "--移除 \r\n";

            sql += "delete SurveyAnswer where SurveyQuestionGID in ( \r\n";
            sql += "select a.gid from SurveyQuestion a inner join Survey b on a.SurveyGID=b.GID where b.SurveyName like '%" + SurveyName + "%' and a.SurveyGID<>'" + SurveyGID + "' \r\n";
            sql += ") \r\n";

            sql += "delete SurveyQuestion where GID in ( \r\n";
            sql += "select a.gid from SurveyQuestion a inner join Survey b on a.SurveyGID=b.GID where b.SurveyName like '%" + SurveyName + "%' and a.SurveyGID<>'" + SurveyGID + "' \r\n";
            sql += ") \r\n";

            sql += "delete SurveyAnalysis where SurveyGID in ( \r\n";
            sql += "select GID from Survey where  SurveyName like '%" + SurveyName + "%' and GID<>'" + SurveyGID + "' \r\n";
            sql += ") \r\n";

            sql += "delete Survey where  SurveyName like '%"+ SurveyName + "%' and GID<>'"+ SurveyGID + "' \r\n";

            return sql;
        }
        #endregion
    }
}

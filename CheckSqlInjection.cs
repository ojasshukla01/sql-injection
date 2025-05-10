using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Controllers
{
    public class CheckSqlInjection
    {


        public bool CheckFromPatern(string userInput)
        {
            bool sqlInjection = false;
            if (userInput.Contains("and 1=1 #") || userInput.ToLower().Contains("and 1=1 #"))
            {
                sqlInjection = true;
            }


            if (userInput.Contains("1&#39; and 1=1 order by 2#") || userInput.ToLower().Contains("1&#39; and 1=1 order by 2#"))
            {
                sqlInjection = true;
            }

            if (userInput.Contains("1’ and 1=1 union select 1,2#") || userInput.ToLower().Contains("1’ and 1=1 union select 1,2#"))
            {
                sqlInjection = true;
            }

            if (userInput.Contains("1’ and 1=1 union select database(),user()#") || userInput.ToLower().Contains("1’ and 1=1 union select database(),user()#"))
            {
                sqlInjection = true;
            }

            if (userInput.Contains("1’ and 1=1 union select null,@@version#") || userInput.ToLower().Contains("1’ and 1=1 union select null,@@version#"))
            {
                sqlInjection = true;
            }

            if (userInput.Contains("1&#39; and 1=1 union select null,table_name from information_schema.tables#") || userInput.ToLower().Contains("1&#39; and 1=1 union select null,table_name from information_schema.tables#"))
            {
                sqlInjection = true;
            }

            if (userInput.Contains("1&#39; and 1=1 union select null,table_name from information_schema.tables where table_schema=database()#") || userInput.ToLower().Contains("1&#39; and 1=1 union select null,table_name from information_schema.tables where table_schema=database()#"))
            {
                sqlInjection = true;
            }



            if (userInput.Contains("1&#39; and 1=1 union select null,column_name from information_schema.columns#") || userInput.ToLower().Contains("1&#39; and 1=1 union select null,column_name from information_schema.columns#"))
            {
                sqlInjection = true;
            }
            if (userInput.Contains("1&#39; and 1=1 union select null,column_name from information_schema.columns where table_name=&#39;accounts&#39;#") || userInput.ToLower().Contains("1&#39; and 1=1 union select null,column_name from information_schema.columns where table_name=&#39;accounts&#39;#"))
            {
                sqlInjection = true;
            }


            if (userInput.Contains("1&#39; and 1=1 union select null,column_name from information_schema.columns where table_name=&#39;users&#39;#") || userInput.ToLower().Contains("1&#39; and 1=1 union select null,column_name from information_schema.columns where table_name=&#39;users&#39;#"))
            {
                sqlInjection = true;
            }

            if (userInput.Contains("1&#39; and 1=1 union select first_name,last_name from users#") || userInput.ToLower().Contains("1&#39; and 1=1 union select first_name,last_name from users#"))
            {
                sqlInjection = true;
            }

            if (userInput.Contains(@"SELECT loginName FROM tblUser WHERE loginName=bob(?(?([a-zA- Z|0-9]+or[a- zA-Z|0-9]+))(?i)(?:[\s*http(s)://].+\?(?:.+\bor|having\b.+)))#") || userInput.ToLower().Contains(@"SELECT loginName FROM tblUser WHERE loginName=bob(?(?([a-zA- Z|0-9]+or[a- zA-Z|0-9]+))(?i)(?:[\s*http(s)://].+\?(?:.+\bor|having\b.+)))#"))
            {
                sqlInjection = true;
            }


            if (userInput.Contains("SELECT accounts FROM users WHERE login=’’ AND pass=’’ AND pin= convert (int,(select top 1 name from sysobjects where xtype=’u’))#") || userInput.ToLower().Contains("SELECT accounts FROM users WHERE login=’’ AND pass=’’ AND pin= convert (int,(select top 1 name from sysobjects where xtype=’u’))#"))
            {
                sqlInjection = true;
            }
            if (userInput.Contains("SELECT accounts FROM users WHERE login=’doe’ AND pass=’’; drop table users -- ’ AND pin=1523#") || userInput.ToLower().Contains("SELECT accounts FROM users WHERE login=’doe’ AND pass=’’; drop table users -- ’ AND pin=1523#"))
            {
                sqlInjection = true;
            }




            if (userInput.Contains("SELECT accounts FROM users WHERE login=’’ or 1=1 -- AND pass=’’ AND pin=1241#") || userInput.ToLower().Contains("SELECT accounts FROM users WHERE login=’’ or 1=1 -- AND pass=’’ AND pin=1241#"))
            {
                sqlInjection = true;
            }


            if (userInput.Contains("SELECT accounts FROM users WHERE login=’legalUser’; exec(char(0x73687574646f776e)) -- AND pass=’’#") || userInput.ToLower().Contains("SELECT accounts FROM users WHERE login=’legalUser’; exec(char(0x73687574646f776e)) -- AND pass=’’#"))
            {
                sqlInjection = true;
            }


            if (userInput.Contains(@"SELECT loginName,accountNo FROM tblUser WHERE loginName=john(?(?([a-zA- Z|0-9]+or[a- zA-Z|0-9]+))(?i)(?:[\s*http(s)://].+\?(?:.+\bor|having\b.+)))#") || userInput.ToLower().Contains(@"SELECT loginName,accountNo FROM tblUser WHERE loginName=john(?(?([a-zA- Z|0-9]+or[a- zA-Z|0-9]+))(?i)(?:[\s*http(s)://].+\?(?:.+\bor|having\b.+)))#"))
            {
                sqlInjection = true;
            }

            if (userInput.Contains("SELECT username FROM users WHERE ID=’’ or 1=1 -- AND password=’’#") || userInput.ToLower().Contains("SELECT username FROM users WHERE ID=’’ or 1=1 -- AND password=’’#"))
            {
                sqlInjection = true;
            }

            if (userInput.Contains("SELECT accounts FROM users WHERE login=’jon’ AND pass=’’; drop table users -- ’ AND pin=4587#") || userInput.ToLower().Contains("SELECT accounts FROM users WHERE login=’jon’ AND pass=’’; drop table users -- ’ AND pin=4587#"))
            {
                sqlInjection = true;
            }






            if (!sqlInjection)
            {

                sqlInjection = IsSqlInjectionFound(userInput);
            }




            return sqlInjection;





        }
        public bool IsSqlInjectionFound(string userInput)
        {
            bool result = false;

            bool isSQLInjection = false;

            string[] sqlCheckList = { "--",

                                       ";--",

                                       ";",

                                       "/*",

                                       "*/",

                                        "@@",

                                        "@",

                                        "char",

                                       "nchar",

                                       "varchar",

                                       "nvarchar",

                                       "alter",

                                       "begin",

                                       "cast",

                                       "create",

                                       "cursor",

                                       "declare",

                                       "delete",

                                       "drop",

                                       "end",

                                       "exec",

                                       "execute",

                                       "fetch",

                                            "insert",

                                          "kill",

                                             "select",

                                           "sys",

                                            "sysobjects",

                                            "syscolumns",

                                           "table",

                                           "update"

                                       };

            string CheckString = userInput.Replace("'", "''");

            for (int i = 0; i <= sqlCheckList.Length - 1; i++)
            {

                if ((CheckString.IndexOf(sqlCheckList[i],

                    StringComparison.OrdinalIgnoreCase) >= 0))

                { isSQLInjection = true; }
            }

            return isSQLInjection;
        }


        public string ReplcaeWords(string userinput)
        {

            string[] sqlCheckList = { "--",

                                       ";--",

                                       ";",

                                       "/*",

                                       "*/",

                                        "@@",

                                        "@",

                                        "char",

                                       "nchar",

                                       "varchar",

                                       "nvarchar",

                                       "alter",

                                       "begin",

                                       "cast",

                                       "create",

                                       "cursor",

                                       "declare",

                                       "delete",

                                       "drop",

                                       "end",

                                       "exec",

                                       "execute",

                                       "fetch",

                                            "insert",

                                          "kill",

                                             "select",

                                           "sys",

                                            "sysobjects",

                                            "syscolumns",

                                           "table",

                                           "update"

                                       };

            string CheckString = userinput.Replace("'", "''");

            for (int i = 0; i <= sqlCheckList.Length - 1; i++)
            {

                if ((CheckString.IndexOf(sqlCheckList[i],

                    StringComparison.OrdinalIgnoreCase) >= 0))

                { userinput.Replace(sqlCheckList[i], string.Empty); }
            }


            return userinput;
        }

        public string ReplaceFromPatern(string userInput)
        {
            bool sqlInjection = false;
            if (userInput.Contains("and 1=1 #") || userInput.ToLower().Contains("and 1=1 #"))
            {
                userInput = userInput.Replace("and 1=1 #",string.Empty);
            }


            if (userInput.Contains("1&#39; and 1=1 order by 2#") || userInput.ToLower().Contains("1&#39; and 1=1 order by 2#"))
            {
                userInput = userInput.ToLower().Replace("1&#39; and 1=1 order by 2#", string.Empty);
            }

            if (userInput.Contains("1’ and 1=1 union select 1,2#") || userInput.ToLower().Contains("1’ and 1=1 union select 1,2#"))
            {
                userInput = userInput.ToLower().Replace("1’ and 1=1 union select 1,2#", string.Empty);
            }

            if (userInput.Contains("1’ and 1=1 union select database(),user()#") || userInput.ToLower().Contains("1’ and 1=1 union select database(),user()#"))
            {
                userInput = userInput.ToLower().Replace("1’ and 1=1 union select database(),user()#", string.Empty);
            }

            if (userInput.Contains("1’ and 1=1 union select null,@@version#") || userInput.ToLower().Contains("1’ and 1=1 union select null,@@version#"))
            {
                userInput = userInput.ToLower().Replace("1’ and 1=1 union select null,@@version#", string.Empty);
            }

            if (userInput.Contains("1&#39; and 1=1 union select null,table_name from information_schema.tables#") || userInput.ToLower().Contains("1&#39; and 1=1 union select null,table_name from information_schema.tables#"))
            {
                userInput = userInput.ToLower().Replace("1&#39; and 1=1 union select null,table_name from information_schema.tables#", string.Empty);
            }

            if (userInput.Contains("1&#39; and 1=1 union select null,table_name from information_schema.tables where table_schema=database()#") || userInput.ToLower().Contains("1&#39; and 1=1 union select null,table_name from information_schema.tables where table_schema=database()#"))
            {
                userInput = userInput.ToLower().Replace("1&#39; and 1=1 union select null,table_name from information_schema.tables where table_schema=database()#", string.Empty);
            }

           

            if (userInput.Contains("1&#39; and 1=1 union select null,column_name from information_schema.columns#") || userInput.ToLower().Contains("1&#39; and 1=1 union select null,column_name from information_schema.columns#"))
            {
                userInput = userInput.ToLower().Replace("1&#39; and 1=1 union select null,column_name from information_schema.columns#", string.Empty);
            }
            if (userInput.Contains("1&#39; and 1=1 union select null,column_name from information_schema.columns where table_name=&#39;accounts&#39;#") || userInput.ToLower().Contains("1&#39; and 1=1 union select null,column_name from information_schema.columns where table_name=&#39;accounts&#39;#"))
            {
                userInput = userInput.ToLower().Replace("1&#39; and 1=1 union select null,column_name from information_schema.columns where table_name=&#39;accounts&#39;#", string.Empty);
            }


            if (userInput.Contains("1&#39; and 1=1 union select null,column_name from information_schema.columns where table_name=&#39;users&#39;#") || userInput.ToLower().Contains("1&#39; and 1=1 union select null,column_name from information_schema.columns where table_name=&#39;users&#39;#"))
            {
                userInput = userInput.ToLower().Replace("1&#39; and 1=1 union select null,column_name from information_schema.columns where table_name=&#39;users&#39;#", string.Empty);
            }
            
            if (userInput.Contains("1&#39; and 1=1 union select first_name,last_name from users#") || userInput.ToLower().Contains("1&#39; and 1=1 union select first_name,last_name from users#"))
            {
                userInput = userInput.ToLower().Replace("1&#39; and 1=1 union select first_name,last_name from users#", string.Empty);
            }
            
            if (userInput.Contains(@"SELECT loginName FROM tblUser WHERE loginName=bob(?(?([a-zA- Z|0-9]+or[a- zA-Z|0-9]+))(?i)(?:[\s*http(s)://].+\?(?:.+\bor|having\b.+)))#") || userInput.ToLower().Contains(@"SELECT loginName FROM tblUser WHERE loginName=bob(?(?([a-zA- Z|0-9]+or[a- zA-Z|0-9]+))(?i)(?:[\s*http(s)://].+\?(?:.+\bor|having\b.+)))#"))
            {
                userInput = userInput.ToLower().Replace(@"SELECT loginName FROM tblUser WHERE loginName=bob(?(?([a-zA- Z|0-9]+or[a- zA-Z|0-9]+))(?i)(?:[\s*http(s)://].+\?(?:.+\bor|having\b.+)))#", string.Empty);
            }
           

            if (userInput.Contains("SELECT accounts FROM users WHERE login=’’ AND pass=’’ AND pin= convert (int,(select top 1 name from sysobjects where xtype=’u’))#") || userInput.ToLower().Contains("SELECT accounts FROM users WHERE login=’’ AND pass=’’ AND pin= convert (int,(select top 1 name from sysobjects where xtype=’u’))#"))
            {
                userInput = userInput.ToLower().Replace("SELECT accounts FROM users WHERE login=’’ AND pass=’’ AND pin= convert (int,(select top 1 name from sysobjects where xtype=’u’))#", string.Empty);
            }
            if (userInput.Contains("SELECT accounts FROM users WHERE login=’doe’ AND pass=’’; drop table users -- ’ AND pin=1523#") || userInput.ToLower().Contains("SELECT accounts FROM users WHERE login=’doe’ AND pass=’’; drop table users -- ’ AND pin=1523#"))
            {
                userInput = userInput.ToLower().Replace("SELECT accounts FROM users WHERE login=’doe’ AND pass=’’; drop table users -- ’ AND pin=1523#", string.Empty);
            }
            



            if (userInput.Contains("SELECT accounts FROM users WHERE login=’’ or 1=1 -- AND pass=’’ AND pin=1241#") || userInput.ToLower().Contains("SELECT accounts FROM users WHERE login=’’ or 1=1 -- AND pass=’’ AND pin=1241#"))
            {
                userInput = userInput.ToLower().Replace("SELECT accounts FROM users WHERE login=’’ or 1=1 -- AND pass=’’ AND pin=1241#", string.Empty);
            }


            if (userInput.Contains("SELECT accounts FROM users WHERE login=’legalUser’; exec(char(0x73687574646f776e)) -- AND pass=’’#") || userInput.ToLower().Contains("SELECT accounts FROM users WHERE login=’legalUser’; exec(char(0x73687574646f776e)) -- AND pass=’’#"))
            {
                userInput = userInput.ToLower().Replace("SELECT accounts FROM users WHERE login=’legalUser’; exec(char(0x73687574646f776e)) -- AND pass=’’#", string.Empty);
            }


            if (userInput.Contains(@"SELECT loginName,accountNo FROM tblUser WHERE loginName=john(?(?([a-zA- Z|0-9]+or[a- zA-Z|0-9]+))(?i)(?:[\s*http(s)://].+\?(?:.+\bor|having\b.+)))#") || userInput.ToLower().Contains(@"SELECT loginName,accountNo FROM tblUser WHERE loginName=john(?(?([a-zA- Z|0-9]+or[a- zA-Z|0-9]+))(?i)(?:[\s*http(s)://].+\?(?:.+\bor|having\b.+)))#"))
            {
                userInput = userInput.ToLower().Replace(@"SELECT loginName,accountNo FROM tblUser WHERE loginName=john(?(?([a-zA- Z|0-9]+or[a- zA-Z|0-9]+))(?i)(?:[\s*http(s)://].+\?(?:.+\bor|having\b.+)))#", string.Empty);
            }

            if (userInput.Contains("SELECT username FROM users WHERE ID=’’ or 1=1 -- AND password=’’#") || userInput.ToLower().Contains("SELECT username FROM users WHERE ID=’’ or 1=1 -- AND password=’’#"))
            {
                userInput = userInput.ToLower().Replace("SELECT username FROM users WHERE ID=’’ or 1=1 -- AND password=’’#", string.Empty);
            }

            if (userInput.Contains("SELECT accounts FROM users WHERE login=’jon’ AND pass=’’; drop table users -- ’ AND pin=4587#") || userInput.ToLower().Contains("SELECT accounts FROM users WHERE login=’jon’ AND pass=’’; drop table users -- ’ AND pin=4587#"))
            {
                userInput = userInput.ToLower().Replace("SELECT accounts FROM users WHERE login=’jon’ AND pass=’’; drop table users -- ’ AND pin=4587#", string.Empty);
            }




            if (!sqlInjection)
            {

                sqlInjection = IsSqlInjectionFound(userInput);
            }




            return userInput;





        }
      
    }
}
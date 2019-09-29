using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LankaStocks.dev
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Core.IsDebug = true;
            LankaStocks.Program.Main();
        }
        static void Draw()
        {
            Console.WriteLine(@" _______             _______                                                              ");
            Console.WriteLine(@"|       |           |       |                                       ------------------    ");
            Console.WriteLine(@"|       |           |       |                                      /  ---------------     ");
            Console.WriteLine(@"|       |           |       |               _______               /  /                    ");
            Console.WriteLine(@"|       |           |       |              |       |             /  /                     ");
            Console.WriteLine(@"|       |           |       |              |       |            |  |                      ");
            Console.WriteLine(@"|       |___________|       |       _______|       |_______     |  |                      ");
            Console.WriteLine(@"|                           |      |                       |    |  |          _________   ");
            Console.WriteLine(@"|                           |      |                       |    |  |         |______  |   ");
            Console.WriteLine(@"|        ___________        |      |_______         _______|    |  |                | |   ");
            Console.WriteLine(@"|       |           |       |              |       |            |  |                | |   ");
            Console.WriteLine(@"|       |           |       |              |       |             \  \               | |   ");
            Console.WriteLine(@"|       |           |       |              |_______|              \  \              | |   ");
            Console.WriteLine(@"|       |           |       |                                      \  \             | |   ");
            Console.WriteLine(@"|       |           |       |                                       \  \------------| |   ");
            Console.WriteLine(@"|_______|           |_______|                                        \----------------|   ");
            Console.WriteLine("                                             Harindu + Galaaaaaaaa                        \n \n \n");
            Console.WriteLine(
"                    \n" +
"   ---------        \n" +
"    Harindu         \n" +
"   ---------        \n" +
"                    \n" +
"             .-----.\r\n" +
"            /       `\\\r\n" +
"          _|_         |\r\n" +
"         /   \\        | \r\n" +
"         '==='        |\r\n" +
"         . ' .        |\r\n" +
"        . : ' .       |\r\n" +
"           '.         |\r\n" +
"       . '    .       |\r\n" +
"        .-\"\"\"-.       |\r\n" +
"       /  \\___ \\      |\r\n" +
"       |/`    \\|      |\r\n" +
"       (  a  a )      |\r\n" +
"       |   _\\ |       |\r\n" +
"       )\\  =  /       |\r\n" +
"   _.-'  '---;        |\r\n" +
" /`           `-.     |\r\n" +
"|                \\    |\r\n" +
"|    |   .  & .   \\   |\r\n" +
"\\    /      &   |  ;  |\r\n" +
"|   |           |  ;  |\r\n" +
"|   /\\          /  |  |\r\n" +
"\\   \\ )   -:-  /\\  \\  |\r\n" +
" `.  `-.  -:-  | \\  \\_|\r\n" +
"   '-.  `-.    (  './\\`\\\r\n" +
"    / `'-. `\\  |    \\/_/\r\n" +
"    |    \\  |  |      |\r\n" +
"    |    /'-\\  /      |\r\n" +
"     \\   \\   | |      |\r\n" +
"      \\   )_/\\ |      |\r\n" +
"       \\      \\|      |\r\n" +
"        \\      \\      |\r\n" +
"         '.     |     |\r\n" +
"           /   /      |\r\n" +
"          /  .';      |\r\n" +
"        /`  /  |      |\r\n" +
"       /   /   |      |\r\n" +
" jgs  |  .' \\  |      |\r\n" +
"      /  \\  )  |      |\r\n" +
"      \\   \\ /  '-.._  |\r\n" +
"       '.ooO\\__._.Ooo |\r\n \n");





            Console.WriteLine(" \n \n  Galaa In the next door \n \n" +
"                       ,ad8888888888888888ba,\r\n" +
"                     ad88888888888888888888888a,\r\n" +
"                   a88888\\\"8888888888888888888888,\r\n" +
"                ,8888\"\\ \\ \\\"P88888888888888888888b,\r\n" +
"                d88 \\ \\       `\"\"P88888888888888888,\r\n" +
"              ,8888b               \"\"88888888888888,\r\n" +
"              d8P'''  ,aa,              \"\"888888888b\r\n" +
"              888bbdd888888ba,  ,I         \"88888888,\r\n" +
"              8888888888888888ba8\"         ,88888888b\r\n" +
"             ,888888888888888888b,        ,8888888888\r\n" +
"             (88888888888888888888,      ,88888888888,\r\n" +
"             d888888888888888888888,    ,8   \"8888888b\r\n" +
"             88888888888888888888888  .;8'\"\"\"  (888888\r\n" +
"             8888888888888I\"8888888P ,8\" ,aaa,  888888\r\n" +
"             888888888888I:8888888\" ,8\"  'b8d'  (88888\r\n" +
"             (8888888888I'888888P' ,8) \\         88888\r\n" +
"              88888888I\"  8888P'  ,8\")  \\        88888\r\n" +
"              8888888I'   888\"   ,8\" (   )       88888\r\n" +
"              (8888I\"     \"88,  ,8\"             ,8888P\r\n" +
"               888I'       \"P8 ,8\"   ____      ,88888)\r\n" +
"              (88I'          \",8\"  M\"\"\"\"\"\"8888888'\r\n" +
"             ,8I\"            ,8(    \"aaaa\"   ,8888888\r\n" +
"         ,8I'             ,888a           ,8888888)\r\n" +
"       ,8I'            ,888888,       ,888888888\r\n" +
"    ,8I'             ,8888888'`-===-'888888888'\r\n" +
" ,8I'            ,8888888\"        88888888\"\r\n" +
" 8I'            ,8\"    88         \"888888P\r\n" +
"8I            ,8'     88          `P888\"\r\n" +
"8I           ,8I      88            \"8ba,.\r\n" +
"(8,         ,8P'      88              88\"\"8bma,.\r\n" +
" 8I        ,8P'       88,              \"8b   \"\"P8ma,\r\n" +
" (8,      ,8d\"        `88,               \"8b     `\"8a\r\n" +
"  8I     ,8dP         ,8X8,                \"8b.    :8b\r\n" +
"  (8    ,8dP'  ,I    ,8XXX8,                `88,    8)\r\n" +
"   8,   8dP'  ,I    ,8XxxxX8,     I,         8X8,  ,8\r\n" +
"   8I   8P'  ,I    ,8XxxxxxX8,     I,        `8X88,I8\r\n" +
"   I8,  \"   ,I    ,8XxxxxxxxX8b,    I,        8XXX88I,\r\n" +
"   `8I      I'  ,8XxxxxxxxxxxxXX8    I        8XXxxXX8,\r\n" +
"    8I     (8  ,8XxxxxxxxxxxxxxxX8   I        8XxxxxxXX8,\r\n" +
"   ,8I     I[ ,8XxxxxxxxxxxxxxxxxX8  8        8XxxxxxxxX8,\r\n" +
"   d8I,    I[ 8XxxxxxxxxxxxxxxxxxX8b 8       (8XxxxxxxxxX8,\r\n" +
"   888I    `8,8XxxxxxxxxxxxxxxxxxxX8 8,     ,8XxxxxxxxxxxX8\r\n" +
"   8888,    \"88XxxxxxxxxxxxxxxxxxxX8)8I    .8XxxxxxxxxxxxX8\r\n" +
"  ,8888I     88XxxxxxxxxxxxxxxxxxxX8 `8,  ,8XxxxxxxxxxxxX8\"\r\n" +
"  d88888     `8XXxxxxxxxxxxxxxxxxX8'  `8,,8XxxxxxxxxxxxX8\"\r\n" +
"  888888I     `8XXxxxxxxxxxxxxxxX8'    \"88XxxxxxxxxxxxX8\"\r\n" +
"  88888888bbaaaa88XXxxxxxxxxxxXX8)      )8XXxxxxxxxxXX8\"\r\n" +
"  8888888I, ``\"\"\"\"\"\"8888888888888888aaaaa8888XxxxxXX8\"\r\n" +
"  (8888888I,                      .  ```\"\"\"\"\"88888P\"\r\n" +
"   88888888I,                   ,8I   8,       I8\"\r\n" +
"    \"\"\"88888I,                ,8I'    \"I8,    ;8\"\r\n" +
"           `8I,             ,8I'       `I8,   8)\r\n" +
"            `8I,           ,8I'          I8  :8'\r\n" +
"             `8I,         ,8I'           I8  :8\r\n" +
"              `8I       ,8I'             `8  (8\r\n" +
"               8I     ,8I'                8  (8;\r\n" +
"               8I    ,8\"                  I   88,\r\n" +
"              .8I   ,8'                       8\"8,\r\n" +
"              (PI   '8                       ,8,`8,\r\n" +
"             .88'            ,@           .a8X8,`8,\r\n" +
"             (88             @@         ,a8XX888,`8,\r\n" +
"            (888             @'       ,d8XX8\"  \"b `8,\r\n" +
"           .8888,                     a8XXX8\"    \"a `8,\r\n" +
"          .888X88                   ,d8XX8I\"      9, `8,\r\n" +
"         .88:8XX8,                 a8XxX8I'       `8  `8,\r\n" +
"        .88' 8XxX8a             ,ad8XxX8I'        ,8   `8,\r\n" +
"        d8'  8XxxxX8ba,      ,ad8XxxX8I\"          8  ,  `8,\r\n" +
"       (8I   8XxxxxxX888888888XxxxX8I\"            8  II  `8\r\n" +
"       8I'   \"8XxxxxxxxxxxxxxxxxxX8I'            (8  8)   8;\r\n" +
"      (8I     8XxxxxxxxxxxxxxxxxX8\"              (8  8)   8I\r\n" +
"      8P'     (8XxxxxxxxxxxxxxX8I'                8, (8   :8\r\n" +
"     (8'       8XxxxxxxxxxxxxxX8'                 `8, 8    8\r\n" +
"     8I        `8XxxxxxxxxxxxX8'                   `8,8   ;8\r\n" +
"     8'         `8XxxxxxxxxxX8'                     `8I  ,8'\r\n" +
"     8           `8XxxxxxxxX8'                       8' ,8'\r\n" +
"     8            `8XxxxxxX8'                        8 ,8'\r\n" +
"     8             `8XxxxX8'                        d' 8'\r\n" +
"     8              `8XxxX8                         8 8'\r\n" +
"     8                \"8X8'                         \"8\"\r\n" +
"     8,                `88     Love you              8\r\n" +
"     8I                ,8'           Harindu        d)\r\n" +
"     `8,               d8                          ,8\r\n" +
"      (b               8'                         ,8'\r\n" +
"       8,             dP                         ,8'\r\n" +
"       (b             8'                        ,8'\r\n" +
"        8,           d8                        ,8'\r\n" +
"        (b           8'                       ,8'\r\n" +
"         8,         a8       Gala            ,8'\r\n" +
"         (b         8'        Gala          ,8'\r\n" +
"          8,       ,8                      ,8'\r\n" +
"          (b       8'                     ,8'\r\n" +
"           8,     ,8                     ,8'\r\n" +
"           (b     8'                    ,8'\r\n" +
"            8,   d8                    ,8'\r\n" +
"            (b  ,8'                   ,8'\r\n" +
"             8,,I8                   ,8'\r\n" +
"             I8I8'                  ,8'\r\n" +
"             `I8I                  ,8'\r\n" +
"              I8'                 ,8'\r\n" +
"              \"8                 ,8'\r\n" +
"              (8                ,8'\r\n" +
"              8I               ,8'\r\n" +
"              (b,   8,        ,8)\r\n" +
"              `8I   \"88      ,8i8,\r\n" +
"               (b,          ,8\"8\")\r\n" +
"               `8I  ,8      8) 8 8\r\n" +
"                8I  8I      \"  8 8\r\n" +
"                (b  8I         8 8\r\n" +
"                `8  (8,        b 8,\r\n" +
"                 8   8)        \"b\"8,\r\n" +
"                 8   8(         \"b\"8\r\n" +
"                 8   \"I          \"b8,\r\n" +
"                 8                `8)\r\n" +
"                 8                 I8\r\n" +
"                 8                 (8\r\n" +
"                 8,                 8,\r\n" +
"                 Ib                 8)\r\n" +
"                 (8                 I8\r\n" +
"                  8                 I8\r\n" +
"                  8                 I8\r\n" +
"                  8,                I8\r\n" +
"                  Ib                8I\r\n" +
"                  (8               (8'\r\n" +
"                   8               I8\r\n" +
"                   8,              8I\r\n" +
"                   Ib             (8'\r\n" +
"                   (8             I8\r\n" +
"                   `8             8I\r\n" +
"                    8            (8'\r\n" +
"                    8,           I8\r\n" +
"                    Ib           8I\r\n" +
"                    (8           8'\r\n" +
"                     8,         (8\r\n" +
"                     Ib         I8\r\n" +
"                     (8         8I\r\n" +
"                     (8         8I\r\n" +
"                      8,        8'\r\n" +
"                      (b       (8\r\n" +
"                       8,      I8\r\n" +
"                       I8      I8\r\n" +
"                       (8      I8\r\n" +
"                        8      I8,\r\n" +
"                        8      8 8,\r\n" +
"                        8,     8 8'\r\n" +
"                       ,I8     \"8\"\r\n" +
"                      ,8\"8,     \"b\r\n" +
"                     ,8' `8      8\r\n" +
"                    ,8'   8      8,\r\n" +
"                   ,8'    (a     \"b\r\n" +
"                  ,8'     `8      (b\r\n" +
"                  I8/      8       8,\r\n" +
"                  I8-/     8       `8,\r\n" +
"                  (8/-/    8        `8,\r\n" +
"                   8I/-/  ,8         `8\r\n" +
"                   `8I/--,I8        \\-8)\r\n" +
"                    `8I,,d8I       \\-\\8)\r\n" +
"                      \"bdI\"8,     \\-\\I8\r\n" +
"                           `8,   \\-\\I8'\r\n" +
"                            `8,,--\\I8'\r\n" +
"                             `Ib,,I8'\r\n" +
"                              `I8I'\r\n");
        }

        static void Draw1()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"$#$                                #$#                $#$$#$             $#$    $#$       $#$                 #$#                      #$#$#$#$    $#$$#$$#$$#$$#$$#$$#$         $#$$#$                                                   ");
            Console.WriteLine(@"$#$                               $#$#$               $#$ $#$            $#$    $#$      $#$                 $#$#$                   $#$#$#        $#$$#$$#$$#$$#$$#$$#$        $#$  $#$                                             ");
            Console.WriteLine(@"$#$                              $#$ $#$              $#$  $#$           $#$    $#$     $#$                 $#$ $#$                 $#$#$                   $#$                $#$    $#$                          ");
            Console.WriteLine(@"$#$                             $#$   $#$             $#$   $#$          $#$    $#$    $#$                 $#$   $#$               $#$#$                    $#$               $#$      $#$                                    ");
            Console.WriteLine(@"$#$                            $#$     $#$            $#$    $#$         $#$    $#$   $#$                 $#$     $#$              $#$#$                    $#$              $#$        $#$                                 ");
            Console.WriteLine(@"$#$                           $#$       $#$           $#$     $#$        $#$    $#$  $#$                 $#$       $#$              $#$#$                   $#$             $#$          $#$                                  ");
            Console.WriteLine(@"$#$                          $#$         $#$          $#$      $#$       $#$    $#$ $#$                 $#$         $#$               $#$#$                 $#$            $#$            $#$                                    ");
            Console.WriteLine(@"$#$                         $#$           $#$         $#$       $#$      $#$    $#$  $#$               $#$           $#$                $#$#$               $#$            $#$            $#$                              ");
            Console.WriteLine(@"$#$                        $#$#$#$#$#$#$#$#$#$        $#$        $#$     $#$    $#$   $#$             $#$#$#$#$#$#$#$#$#$                $#$#$              $#$             $#$          $#$                                    ");
            Console.WriteLine(@"$#$                       $#$#$#$#$#$#$#$#$#$#$       $#$         $#$    $#$    $#$    $#$           $#$#$#$#$#$#$#$#$#$#$                $#$#$             $#$              $#$        $#$                                          ");
            Console.WriteLine(@"$#$                      $#$                 $#$      $#$          $#$   $#$    $#$     $#$         $#$                 $#$               $#$#$             $#$               $#$      $#$                                         ");
            Console.WriteLine(@"$#$                     $#$                   $#$     $#$           $#$  $#$    $#$      $#$       $#$                   $#$             $#$#$              $#$                $#$    $#$                             ");
            Console.WriteLine(@"$#$$#$$#$$#$$#$$#$$    $#$                     $#$    $#$            $#$ $#$    $#$       $#$     $#$                     $#$         $#$#$#                $#$                 $#$  $#$                                                       ");
            Console.WriteLine(@"$#$$#$$#$$#$$#$$#$$   $#$                       $#$   $#$             $#$$#$    $#$        $#$   $#$                       $#$    $#$#$#$#                  $#$                  $#$$#$                         ");
        }
    }
}

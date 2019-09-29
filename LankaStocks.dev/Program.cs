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
            Draw1();
            Core.IsDebug = true;
            LankaStocks.Program.Main();
        }
        static void Draw()
        {
            Console.WriteLine(@" _______             _______                                               ___________ ");
            Console.WriteLine(@"|       |           |       |                                           _//           |");
            Console.WriteLine(@"|       |           |       |                                         //        ______|");
            Console.WriteLine(@"|       |           |       |               _______                 //       _//       ");
            Console.WriteLine(@"|       |           |       |              |       |               //      //          ");
            Console.WriteLine(@"|       |           |       |              |       |              //      //           ");
            Console.WriteLine(@"|       |___________|       |       _______|       |_______       |      //            ");
            Console.WriteLine(@"|                           |      |                       |      |       |            ");
            Console.WriteLine(@"|                           |      |                       |      |       |            ");
            Console.WriteLine(@"|        ___________        |      |_______         _______|      |       |            ");
            Console.WriteLine(@"|       |           |       |              |       |              |      \\            ");
            Console.WriteLine(@"|       |           |       |              |       |              \\      \\           ");
            Console.WriteLine(@"|       |           |       |              |_______|               \\      \\_         ");
            Console.WriteLine(@"|       |           |       |                                       \\        \\______ ");
            Console.WriteLine(@"|       |           |       |                                         \\_             |");
            Console.WriteLine(@"|_______|           |_______|                                            \\___________|");
            Console.WriteLine(@"                                                                                         Hasindu + Che????????");
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

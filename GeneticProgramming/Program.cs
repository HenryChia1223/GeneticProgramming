﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static GeneticProgramming.create_tree;

namespace GeneticProgramming
{
    class Program
    {
        public static Random rand = new Random();
        public static List<List<Node>> population = new List< List<Node>>();//
        public static List<List<Node>> next_population = new List<List<Node>>();//下一代族群
        public static List<Node> reb = new List<Node>();
        public static List<Node> bst_list = new List<Node>();
        public static List<Node> po;
        public static List<Node> Cross_PostOrder_list_1 = new List<Node>();
        public static List<Node> Cross_PostOrder_list_2 = new List<Node>();
        public static Dictionary<List<Node>, int>  tree_fitness = new Dictionary<List<Node>, int>();//用tree查fitness
        public static List<Node> child1 = new List<Node>();//1st子代
        public static List<Node> child2 = new List<Node>();//2nd子代
        public static Dictionary<int, Node> selection_rate = new Dictionary<int, Node>();//機率字典,輪盤法選到的機率
        public static int best_difference = Int32.MaxValue;//所有代差最少
                                                     
        public static string best_post;//
        public static string best_in;//
        public static int second_difference = Int32.MaxValue;//所有代差次少
        public static List<Node> best_tree = new List<Node>();//最佳樹
        public static List<Node> second_tree = new List<Node>();//次佳樹
        public static List<Node> cross1_tree = new List<Node>();//cross1
        public static List<Node> cross2_tree = new List<Node>();//cross2
        public static List<Node> store_score = new List<Node>();
        public static int best_score;//所有代中最好的
        public static int second_score;
        public static int ger_best_socre = Int32.MinValue;//每代最好
        public static int ger_second_socre = Int32.MinValue;//每代次好
        
        public static Dictionary<Node, int> tem_rate = new Dictionary<Node, int>();
        public static Dictionary<List<Node>, int> dic_score = new Dictionary<List<Node>, int>();//分數字典
    
        public static int poor1_difference_in_ger = Int32.MinValue;//每代最差
        public static int poor2_difference_in_ger = Int32.MinValue;//每代次差
        public static int poor3_difference_in_ger = Int32.MinValue;//每代3rd差
        public static int poor4_difference_in_ger = Int32.MinValue;//每代4th差

        public static List<Node> poor1_tree_in_ger = new List<Node>();//每代最差樹
        public static List<Node> poor2_tree_in_ger = new List<Node>();//每代次差樹
        public static List<Node> poor3_tree_in_ger = new List<Node>();//每代3rd差樹
        public static List<Node> poor4_tree_in_ger = new List<Node>();//每代4th差樹

        public static int best_difference_in_ger = Int32.MaxValue;//每代差最少
        public static int second_difference_in_ger = Int32.MaxValue;//每代差次少
        public static int third_difference_in_ger = Int32.MaxValue;//每代差最少
        public static int fourth_difference_in_ger = Int32.MaxValue;//每代差次少
        public static List<Node> best_tree_in_ger = new List<Node>();//每代最佳樹
        public static List<Node> second_tree_in_ger = new List<Node>();//每代次佳樹
        public static int fitness_sum = 0;
        public static int sum = 0;

        public static List<List<Node>> add_pop = new List<List<Node>>();//突變新增名單
        public static List<List<Node>> del_pop = new List<List<Node>>();//突變刪除名單

        public static int population_size = 150;//人口數   //3 2000*2000 300M//
        public static int generation_num = 1000;//世代數
        public static double mutation_rate = 0.2;//突變率
        public static double cross_rate = 0.8;//交配率

        static void Main(string[] args)
        {
            create_tree.Encode();//編碼

            //產生初代population並存入字典
            for (int i = 0; i < population_size; i++)//根據tree_list產生的
            {
                po = new List<Node>(create_tree.Create_tree());
                population.Add(po);
              //  Console.WriteLine();
            }

            // Console.WriteLine("--------------------以上初始人口----------------------");




            //for (int g = 0; g < generation_num ; g++) 
            //{
            //    //-------------generate_population--------------
            //    //  Console.WriteLine("第" + g  + "代");

            //    //用輪盤法挑兩個個體交配,直到population滿
            //    //若population已經有一樣的




            //    //少一棵樹例外暫時處理
            //    while (population.Count < population_size) 
            //    {
            //        population.Add(population[0]);//把第一顆樹加進去
            //    }



            //    //------------selection---------------
            //    selection();

            //    //mutation
            //    //---------
            //    //---------


            //    //Console.WriteLine("best tree=");

            //    //foreach (Node n in best_tree)
            //    //{
            //    //    Console.WriteLine(n.Action);
            //    //}
            //    //Console.WriteLine();

            //    //Console.WriteLine("second tree=");

            //    //foreach (Node n in second_tree)
            //    //{
            //    //    Console.WriteLine(n.Action);
            //    //}
            //    //Console.WriteLine();



            //    //Console.WriteLine("selsect rate=");

            //    //foreach (KeyValuePair<int, Node> i in selection_rate)
            //    //{


            //    //    Console.WriteLine(i.Key + "     " + i.Value.Action);

            //    //    Console.WriteLine();
            //    //}
            //    //Console.WriteLine();




            //    //po = new List<Node>(best_tree);
            //    //next_population.Add(po); //1st 2nd名必須加進來

            //    //po = new List<Node>(second_tree);
            //    //next_population.Add(po);


            //    for (int i = 0; i < (population_size ) / 2; i++) 
            //    {

            //        //Console.WriteLine("產生第" + i + "次兩個子代");


            //        Lotto(); //抽出cross1 cross2







            //        ////暫時解決cross1 cross2只剩一個node問題
            //        //if (cross1_tree.Count == 1)
            //        //{
            //        //    int a = rand.Next(1, Termianl.Count + 1);//從terminal隨機挑一個
            //        //    Node c = new Node(create_tree.node_id + 1, cross1_tree[0], null, null, cross1_tree[0].High + 1, 1, Termianl[a]);
            //        //    cross1_tree[0].Left = c;
            //        //    cross1_tree[0].Children.Add(c);

            //        //}
            //        //else if (cross2_tree.Count == 1)
            //        //{
            //        //    int a = rand.Next(1, Termianl.Count + 1);//從terminal隨機挑一個
            //        //    Node c = new Node(create_tree.node_id + 1, cross2_tree[0], null, null, cross2_tree[0].High + 1, 1, Termianl[a]);
            //        //    cross2_tree[0].Left = c;
            //        //    cross2_tree[0].Children.Add(c);
            //        //}




            //        //------------crossover---------------
            //        crossover(cross1_tree, cross2_tree);//一次產生兩個子代,更新child1 child2



            //        //mutation
            //        //---------
            //        //---------

            //        po = new List<Node>(child1);
            //        next_population.Add(po);


            //        po = new List<Node>(child2);
            //        next_population.Add(po);

            //    }




            //    Console.WriteLine("best score:" + best_score);
            //    //Console.WriteLine("---------------------------------------------");


            //    //------------------世代結束----------------------



            //    //Console.WriteLine("next_population=");
            //    //foreach (List<Node> p in next_population)
            //    //{
            //    //    foreach (Node n in p)
            //    //    {
            //    //        Console.WriteLine(n.Action);
            //    //    }
            //    //    Console.WriteLine();
            //    //}





            //    child1.Clear();
            //    child2.Clear();
            //    selection_rate.Clear();
            //    population = next_population.ToList();
            //    next_population.Clear();


            //    //Console.WriteLine("new population=");
            //    //foreach (List<Node> p in population)
            //    //{
            //    //    foreach (Node n in p)
            //    //    {
            //    //        Console.WriteLine(n.Action);
            //    //    }
            //    //    Console.WriteLine();
            //    //}
            //    //Console.WriteLine();
            //    //Console.WriteLine("population.count="+population.Count);

            //    //重置
            //   // best_difference = Int32.MaxValue;
            //    best_tree.Clear();
            //   // second_difference = Int32.MaxValue;
            //    second_tree.Clear();


            //    sum = 0;
            //    fitness_sum = 0;
            //    Console.WriteLine("---------------------第"+g+"代結束------------------------");
            //}//輪盤法


            for (int g = 0; g < generation_num; g++)//菁英法
            {
                ger_best_socre = Int32.MinValue;
                ger_second_socre = Int32.MinValue;
                //-------------generate_population--------------
                //  Console.WriteLine("第" + g  + "代");





                //少一棵樹例外暫時處理
                while (population.Count < population_size)
                {
                    population.Add(population[0]);//把第一顆樹加進去
                }



                //------------selection---------------
                selection();

                //mutation
                //---------
                //---------





                //Console.WriteLine("best tree=");

                //foreach (Node n in best_tree)
                //{
                //    Console.WriteLine(n.Action);
                //}
                //Console.WriteLine();

                //Console.WriteLine("second tree=");

                //foreach (Node n in second_tree)
                //{
                //    Console.WriteLine(n.Action);
                //}
                //Console.WriteLine();



                //Console.WriteLine("selsect rate=");

                //foreach (KeyValuePair<int, Node> i in selection_rate)
                //{


                //    Console.WriteLine(i.Key + "     " + i.Value.Action);

                //    Console.WriteLine();
                //}
                //Console.WriteLine();




                //po = new List<Node>(best_tree);
                //next_population.Add(po); //1st 2nd名必須加進來

                //po = new List<Node>(second_tree);
                //next_population.Add(po);


                //Console.WriteLine("產生第" + i + "次兩個子代");


                //Lotto(); //抽出cross1 cross2

                //上一代族群升序排序

                

                //var myList = dic_score.ToList();
                //myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
                //foreach (KeyValuePair<List<Node>, int> i in myList)
                //{
                //    Console.WriteLine(i.Value);
                //}

                
                //foreach (KeyValuePair<List<Node>,int> i in dic_score.ToList())
                //{
                //    if (i.Value == poor1_difference_in_ger)
                //    {
                //        population.Remove(i.Key);
                //        Console.WriteLine("find");
                //    }
                //}


                //if (dic_score.Count > 0)
                //{
                //    List<KeyValuePair<List<Node>, int>> sorting = new List<KeyValuePair<List<Node>, int>>(dic_score);
                //    sorting.Sort(delegate (KeyValuePair<List<Node>, int> s1, KeyValuePair<List<Node>, int> s2) { return s1.Value.CompareTo(s2.Value); });
                //    dic_score.Clear();

                //    foreach (KeyValuePair<List<Node>, int> i in sorting)
                //    {
                //        Console.WriteLine(i.Value);
                //    }
                //}


                //foreach (List<Node> n in population.ToList())
                //{
                //    if (n.Equals(poor1_tree_in_ger))
                //    {
                //        population.Remove(n);
                //    }
                //    if (n.Equals(poor2_tree_in_ger))
                //    {
                //        population.Remove(n);
                //    }
                //}
                //Console.WriteLine("poor1_tree_in_ger:");
                //foreach (Node n in poor1_tree_in_ger)
                //{

                //    Console.WriteLine(n.Action);
                //}
                //Console.WriteLine("----------------");

                //Console.WriteLine("population:");
                //foreach (List<Node> n in population)
                //{
                //    foreach (Node p in n)
                //    {
                //        Console.WriteLine(p.Action);
                //    }
                //    Console.WriteLine();
                //    Console.WriteLine();
                //}



                //複製到下一代族群
                next_population = population.ToList();




                foreach (List<Node> n in next_population.ToList())//刪除每代最差
                {
                    if ( n[0] != null && poor1_tree_in_ger[0] != null && poor1_tree_in_ger[0].Equals(n[0]))
                    {
                        next_population.Remove(n);
                    }

                }
                foreach (List<Node> n in next_population.ToList())//刪除每代次差
                {
                    if (n[0] != null && poor2_tree_in_ger[0] != null && poor2_tree_in_ger[0].Equals(n[0]) )
                    {
                        next_population.Remove(n);
                    }

                }
                //Console.WriteLine(" af population:");
                //foreach (List<Node> n in population)
                //{
                //    foreach (Node p in n)
                //    {
                //        Console.WriteLine(p.Action);
                //    }
                //    Console.WriteLine();
                //    Console.WriteLine();
                //}

              
                

                int popu_size = next_population.Count;//每代人口



                //if (g % 50 == 0 && g != 0)//每50代放入best_tree 
                //{

                //    foreach (List<Node> n in next_population.ToList())//刪除每代3th差
                //    {
                //        if (poor3_tree_in_ger[0].Equals(n[0]) && poor3_tree_in_ger[0]!=null)
                //        {
                //            next_population.Remove(n);
                //        }

                //    }
                //    popu_size--;

                //    po = new List<Node>(best_tree);
                //    next_population.Add(po);

                //    popu_size++;
                //    //po = new List<Node>(second_tree);
                //    //next_population.Add(po);

                //    //popu_size += 2;
                //}
                ////2個
                //if (g % 100 == 0 && g != 0)//每100代放入second_tree 
                //{

                //    foreach (List<Node> n in next_population.ToList())//刪除每代4th差
                //    {
                //        if (poor4_tree_in_ger[0].Equals(n[0]))
                //        {
                //            next_population.Remove(n);
                //        }

                //    }
                //    popu_size--;

                //    po = new List<Node>(second_tree);
                //    next_population.Add(po);

                //    popu_size++;
                //    //po = new List<Node>(second_tree);
                //    //next_population.Add(po);

                //    //popu_size += 2;
                //}


                //if (g % 20 == 0 && g != 0)//每5代放入best_tree 與 second_tree
                //{
                //    po = new List<Node>(best_tree_in_ger);
                //    next_population.Add(po);


                //    po = new List<Node>(second_tree_in_ger);
                //    next_population.Add(po);

                //    popu_size += 2;
                //}

                //if (best_score == ger_best_socre)//若每代最佳等於全局最佳,放入下一代族群
                //{
                //    po = new List<Node>(best_tree_in_ger);
                //    next_population.Add(po);
                //    popu_size ++;
                //}
                //if (second_score == ger_second_socre)
                //{
                //    po = new List<Node>(second_tree_in_ger);
                //    next_population.Add(po);
                //    popu_size ++;
                //}


                //po = new List<Node>(best_tree_in_ger);
                //next_population.Add(po); //1st 2nd名必須加進來

                //po = new List<Node>(second_tree_in_ger);
                //next_population.Add(po);
                ////2個
                //popu_size += 2;


                //交配率0.8
                int cr = rand.Next(1, 11);
                if (cr == 1 || cr == 2) //不交配
                {
                    //
                }
                else //交配
                {
                    ////用postorder重新建一次List<Node>
                    //int e = rand.Next(1, 3);
                    //if (e == 1 || second_tree_in_ger.Count == 0) //best
                    //{
                    //    string p1 = best_tree_in_ger[0].rebuild_pre(best_tree_in_ger[0]);
                    //    best_tree_in_ger[0].preorder_path = "";

                    //    cross1_tree = reb.ToList();//每代的best或second放進cross1
                    //    reb.Clear();
                    //}
                    //else if (e == 2)//second
                    //{
                    //    string p1 = second_tree_in_ger[0].rebuild_pre(second_tree_in_ger[0]);
                    //    second_tree_in_ger[0].preorder_path = "";

                    //    cross1_tree = reb.ToList();//每代的best或second放進cross1
                    //    reb.Clear();
                    //}

                    string p = best_tree_in_ger[0].rebuild_pre(best_tree_in_ger[0]);
                    best_tree_in_ger[0].preorder_path = "";

                    cross1_tree = reb.ToList();//每代的best放進cross1
                    reb.Clear();


                    //int b = rand.Next(0, population.Count);//

                    //string p2 = population[b][0].rebuild_pre(population[b][0]);
                    //population[b][0].preorder_path = "";
                    //cross2_tree = reb.ToList();//population被抽到的放進cross2
                    //reb.Clear();
                    ////1個
                    p = second_tree_in_ger[0].rebuild_pre(second_tree_in_ger[0]);
                    second_tree_in_ger[0].preorder_path = "";

                    cross2_tree = reb.ToList();//每代的second放進cross2
                    reb.Clear();

                    //暫時解決cross1 cross2只剩一個node問題
                    if (cross1_tree.Count == 1)
                    {
                        int a = rand.Next(1, Termianl.Count + 1);//從terminal隨機挑一個
                        Node c = new Node(create_tree.node_id + 1, cross1_tree[0], null, null, cross1_tree[0].High + 1, 1, Termianl[a]);
                        cross1_tree[0].Left = c;
                        c.Parent = cross1_tree[0];

                        string p1 = cross1_tree[0].rebuild_pre(cross1_tree[0]);
                        cross1_tree[0].preorder_path = "";
                        cross1_tree = reb.ToList();//被抽到的放進cross1
                        reb.Clear();


                    }
                    else if (cross2_tree.Count == 1)
                    {
                        int a = rand.Next(1, Termianl.Count + 1);//從terminal隨機挑一個
                        Node c = new Node(create_tree.node_id + 1, cross2_tree[0], null, null, cross2_tree[0].High + 1, 1, Termianl[a]);
                        cross2_tree[0].Left = c;
                        c.Parent = cross2_tree[0];

                        string p1 = cross2_tree[0].rebuild_pre(cross2_tree[0]);
                        cross2_tree[0].preorder_path = "";
                        cross2_tree = reb.ToList();//被抽到的放進cross1
                        reb.Clear();

                    }

                    //------------crossover---------------
                    crossover(cross1_tree, cross2_tree);//一次產生兩個子代,更新child1 child2

                    po = new List<Node>(child1);
                    next_population.Add(po);


                    po = new List<Node>(child2);
                    next_population.Add(po);

                    popu_size += 2;

                }


                while (popu_size < population_size)
                {
                    //從population 抽出人到下一代,直到補滿next

                    int b = rand.Next(0, population.Count);//

                    string p2 = population[b][0].rebuild_pre(population[b][0]);
                    population[b][0].preorder_path = "";

                    po = new List<Node>(reb.ToList());//population被抽到的放進po
                    next_population.Add(po);
                    reb.Clear();

                    popu_size++;

                }


                //int ss;
                //tree_score.tree_node = "3hafC";
                //tree_score.Node_Evaluation();
                //ss = tree_score.node_score;
                //Console.WriteLine("3hafC=" + ss);

                Console.WriteLine("best score:" + best_score);
                string s = best_tree_in_ger[0].PostOrder(best_tree_in_ger[0]);
                best_tree_in_ger[0].postorder_path = "";
                Console.WriteLine("best_tree_in_ger:" +s);
                //Console.WriteLine("postorder:" + best_post);
                //  Console.WriteLine("inorder:" + best_in);
                //  Console.WriteLine("best_tree node:");
                //foreach (Node n in best_tree)
                //{
                //    Console.WriteLine(n.Action);
                //}
                //Console.WriteLine("second_tree node:");
                //foreach (Node n in second_tree)
                //{
                //    Console.WriteLine(n.Action);
                //}
                //Console.WriteLine("---------------------------------------------");


                //------------------世代結束----------------------



                //Console.WriteLine("next_population=");
                //foreach (List<Node> p in next_population)
                //{
                //    foreach (Node n in p)
                //    {
                //        Console.WriteLine(n.Action);
                //    }
                //    Console.WriteLine();
                //}


                child1.Clear();
                child2.Clear();
                selection_rate.Clear();
                population = next_population.ToList();
                next_population.Clear();



                //-----------------------mutation-----------------------------
                ////每個population都有可能突變
                //foreach (List<Node> p in population)
                //{
                //    //突變機率
                //    int z = rand.Next(0,10);//0.01
                //    if (z == 8 )
                //    {
                //        mutation(p);
                //    }
                    
                //}




                //選一個population有可能突變

                int mu_rate = rand.Next(0, 10);//0.2
                if (mu_rate == 8 || mu_rate == 1)
                {
                    int zzz = rand.Next(1, population.Count);//選一個突變,除了root

                    mutation(population[zzz]);
                }
                else
                {
                    //不突變
                }
              

                ////刪除
                //foreach (List<Node> d in del_pop)
                //{
                //    foreach (List<Node> p in population)
                //    {
                //        if (d.All(p.Contains) && d.Count == p.Count)//如果list相等
                //        {
                //            population.Remove(p);
                //        }
                //    }
                //}

                ////新增
                //foreach (List<Node> a in add_pop)
                //{
                //    population.Add(a);
                //}




                //Console.WriteLine("new population=");
                //foreach (List<Node> p in population)
                //{
                //    foreach (Node n in p)
                //    {
                //        Console.WriteLine(n.Action);
                //    }
                //    Console.WriteLine();
                //}
                //Console.WriteLine();
                //Console.WriteLine("population.count="+population.Count);



                Console.WriteLine("generation best score:" + ger_best_socre);
                //重置
                // best_difference = Int32.MaxValue;
                del_pop.Clear();
                add_pop.Clear();
               // best_tree.Clear();
                // second_difference = Int32.MaxValue;
               // second_tree.Clear();
                best_difference_in_ger = Int32.MaxValue;
                second_difference_in_ger = Int32.MaxValue;
                poor1_difference_in_ger = Int32.MinValue;
                poor2_difference_in_ger = Int32.MinValue;
                poor3_difference_in_ger = Int32.MinValue;
                poor4_difference_in_ger = Int32.MinValue;
                best_tree_in_ger.Clear();
                second_tree_in_ger.Clear();
                poor1_tree_in_ger.Clear();
                poor2_tree_in_ger.Clear();
                poor3_tree_in_ger.Clear();
                poor4_tree_in_ger.Clear();
                sum = 0;
                fitness_sum = 0;
               // ger_best_socre = Int32.MinValue;
               // ger_second_socre = Int32.MinValue;
                 Console.WriteLine("---------------------第" + (g+1) + "代結束------------------------");
                if (g == generation_num - 1)
                {
                    Console.WriteLine("-----------------------------------");
                }
            }



            Console.ReadLine();
            
        }



        public static void selection() 
        {
            ////輪盤法
            ////從population中用 "輪盤法" 選出誰可以交配
            //string s1;
            //int treeValue;
            ////先算出每個個體的fitness存入字典
            //foreach (List<Node> p in population)
            //{
            //    try
            //    {
            //        //丟進postorder轉字串
            //        s1 = p[0].PostOrder(p[0]);
            //        p[0].postorder_path = "";
            //        //--------換成樹代表的value---------
            //        tree_score.tree_node = s1;
            //        tree_score.Node_Evaluation();
            //        treeValue = tree_score.node_score;
            //        // Console.WriteLine(s1 + "   score=" + tree_score.node_score + "     count=" + as2.Length);

            //        fitness(p, treeValue);

            //    }
            //    catch (System.IndexOutOfRangeException e)
            //    {
            //        // Set IndexOutOfRangeException to the new exception's InnerException.
            //        Console.WriteLine("index parameter is out of range.");
            //        throw new System.ArgumentOutOfRangeException("index parameter is out of range.", e);
            //    }
            //}






            //菁英法
            //每代最好的跟隨機一個cross
            string s1;
            int treeValue;
            //先算出每個個體的fitness存入字典
            foreach (List<Node> p in population)
            {
                try
                {
                 //   Console.WriteLine("p.count=" + p.Count);
                   //丟進postorder轉字串
                   s1 = p[0].PostOrder(p[0]);
                    p[0].postorder_path = "";
                    //--------換成樹代表的value---------
                    tree_score.tree_node = s1;
                    tree_score.Node_Evaluation();
                    treeValue = tree_score.node_score;
                    // Console.WriteLine(s1 + "   score=" + tree_score.node_score + "     count=" + as2.Length);

                    fitness(p, treeValue);

                }
                catch (System.IndexOutOfRangeException e)
                {
                    // Set IndexOutOfRangeException to the new exception's InnerException.
                    Console.WriteLine("index parameter is out of range.");
                    throw new System.ArgumentOutOfRangeException("index parameter is out of range.", e);
                }
            }




        }

        public static void Lotto()
        {

            ////fitness愈大愈好
            ////抽籤
            //int a = rand.Next(1, fitness_sum);
            //// Console.WriteLine("1st抽到" + a + "號");

            ////用postorder重新建一次List<Node>
            //string p1 = selection_rate[a].rebuild_pre(selection_rate[a]);
            //selection_rate[a].preorder_path = "";
            //cross1_tree = reb.ToList();//被抽到的放進cross1
            //reb.Clear();


            //Console.WriteLine("selection_rate[a]=" + selection_rate[a].Action);
            //Console.WriteLine("cross1_tree=");

            //foreach (Node n in cross1_tree)
            //{
            //    Console.WriteLine(n.Action);
            //}
            //Console.WriteLine("cross1_tree.count=" + cross1_tree.Count);
            //Console.WriteLine();



            //int b = rand.Next(1, fitness_sum);
            //while (selection_rate[b].Equals(selection_rate[a]))//若抽到cross1
            //{
            //    b = rand.Next(1, fitness_sum);//再抽一次
            //}
            //// Console.WriteLine("2ndt抽到" + b + "號");

            //string p2 = selection_rate[b].rebuild_pre(selection_rate[b]);
            //selection_rate[b].preorder_path = "";
            //cross2_tree = reb.ToList();//被抽到的放進cross2
            //reb.Clear();

            //Console.WriteLine("selection_rate[b]=" + selection_rate[b].Action);
            //Console.WriteLine("cross2_tree=");

            //foreach (Node n in cross2_tree)
            //{
            //    Console.WriteLine(n.Action);
            //}
            //Console.WriteLine("cross2_tree.count=" + cross2_tree.Count);
            //Console.WriteLine();


            //fitness越小越好
            
            string s;

            foreach (List<Node> p in population)
            {
                int range1 = sum + 1; //此個體的fintess所佔的機率範圍,下界
                int range2 = sum + Convert.ToInt32((fitness_sum * 10 / tem_rate[p[0]]));//上界,四捨五入到小數點第一位

                for (int i = range1; i <= range2; i++)
                {
                    if (!selection_rate.ContainsKey(i)) //建立機率字典
                    {
                        //dic = new Dictionary<int, List<Node>>(i, tree);
                        selection_rate.Add(i, p[0]);
                    }
                }
                //Console.WriteLine("fitness_sum=" + fitness_sum);
                //  Console.WriteLine("range1=" + range1);

                //  Console.WriteLine("range2=" + range2);

                sum += Convert.ToInt32((fitness_sum * 10 / tem_rate[p[0]]));
                //  Console.WriteLine("sum=" + sum);





                if (tem_rate[p[0]]< best_difference) //找最佳
                {
                    best_difference = tem_rate[p[0]];
                   // best_tree = p.ToList();

                    //丟進postorder轉字串
                    s = p[0].PostOrder(p[0]);
                    p[0].postorder_path = "";
                    //--------換成樹代表的value---------
                    tree_score.tree_node = s;
                    tree_score.Node_Evaluation();
                    best_score = tree_score.node_score;


                    


                }
                else if (tem_rate[p[0]] > best_difference && tem_rate[p[0]] < second_difference) //找次佳
                {
      
                    second_difference = tem_rate[p[0]];
                    second_tree = p;

                    //丟進postorder轉字串
                    s = p[0].PostOrder(p[0]);
                    p[0].postorder_path = "";
                    //--------換成樹代表的value---------
                    tree_score.tree_node = s;
                    tree_score.Node_Evaluation();
                    second_score = tree_score.node_score;
                }
            }
            int a = rand.Next(1, Decimal.ToInt32(sum));
            // Console.WriteLine("1st抽到" + a + "號");

            //用postorder重新建一次List<Node>
            string p1 = selection_rate[a].rebuild_pre(selection_rate[a]);
            selection_rate[a].preorder_path = "";
            cross1_tree = reb.ToList();//被抽到的放進cross1
            reb.Clear();


            int b = rand.Next(1, Decimal.ToInt32(sum));
            while (selection_rate[b].Equals(selection_rate[a]))//若抽到cross1
            {
                b = rand.Next(1, Decimal.ToInt32(sum));//再抽一次
            }
            // Console.WriteLine("2ndt抽到" + b + "號");

            string p2 = selection_rate[b].rebuild_pre(selection_rate[b]);
            selection_rate[b].preorder_path = "";
            cross2_tree = reb.ToList();//被抽到的放進cross2
            reb.Clear();




            //fitness愈小愈好(輪盤)

            //foreach (List<Node> p in population)
            //{
            //    int range1 = Decimal.ToInt32(sum) + 1; //此個體的fintess所佔的機率範圍,下界
            //    int range2 = Decimal.ToInt32(sum) + Decimal.ToInt32((decimal)(fitness_sum * tem_rate[p[0]]));//上界
            //    Console.WriteLine("tem_rate[p[0]]=" +(decimal) tem_rate[p[0]]);
            //    Console.WriteLine("range1=" + range1);

            //    Console.WriteLine("range2=" + range2);

            //    for (int i = range1; i <= range2; i++)
            //    {
            //        if (!selection_rate.ContainsKey(i)) //建立機率字典
            //        {
            //            //dic = new Dictionary<int, List<Node>>(i, tree);
            //            selection_rate.Add(i, p[0]);
            //        }
            //    }
            //    Console.WriteLine("fitness_sum=" + fitness_sum);
            //    Console.WriteLine("fitness_sum*tem_rate[p[0]]=" + (decimal)(fitness_sum * tem_rate[p[0]]));
            //    sum += Decimal.ToInt32((decimal)(fitness_sum * tem_rate[p[0]])); //加入futness_sum


            //    if (fitness_sum * tem_rate[p[0]] < best_score) //找最佳
            //    {
            //        best_score = Decimal.ToInt32((decimal)(fitness_sum * tem_rate[p[0]]));
            //        best_tree = p;


            //    }
            //    else if (fitness_sum * tem_rate[p[0]] > best_score && fitness_sum * tem_rate[p[0]] < second_score) //找次佳
            //    {
            //        second_score = Decimal.ToInt32((decimal)(fitness_sum * tem_rate[p[0]]));
            //        second_tree = p;

            //    }



            //}


            //int a = rand.Next(1, Decimal.ToInt32(sum));
            //// Console.WriteLine("1st抽到" + a + "號");

            ////用postorder重新建一次List<Node>
            //string p1 = selection_rate[a].rebuild_pre(selection_rate[a]);
            //selection_rate[a].preorder_path = "";
            //cross1_tree = reb.ToList();//被抽到的放進cross1
            //reb.Clear();


            //int b = rand.Next(1, Decimal.ToInt32(sum));
            //while (selection_rate[b].Equals(selection_rate[a]))//若抽到cross1
            //{
            //    b = rand.Next(1, Decimal.ToInt32(sum));//再抽一次
            //}
            //// Console.WriteLine("2ndt抽到" + b + "號");

            //string p2 = selection_rate[b].rebuild_pre(selection_rate[b]);
            //selection_rate[b].preorder_path = "";
            //cross2_tree = reb.ToList();//被抽到的放進cross2
            //reb.Clear();






        }



        public static void crossover(List<Node> cross1, List<Node> cross2)
        {
            List<Node> better_cross = new List<Node>();


            //crossovwe_test     1.(尚未限制交換後總層數,未來可用交換後總層數不大於5才能交換)
            //                   2.沒有crossover rate
            //                   3.tree大小沒有限制,一直cross有可能stack overflow

            string st = cross1[0].PostOrder(cross1[0]);
           // Console.WriteLine("一開始best_tree=" + st);
            cross1[0].postorder_path = "";

            st = cross2[0].PostOrder(cross2[0]);
           // Console.WriteLine("一開始s_tree=" + st);
            cross2[0].postorder_path = "";


            

            //選出兩棵樹各自要交換的節點子樹
            int a1 = rand.Next(1, cross1.Count);
            int b1 = rand.Next(1, cross2.Count);

           // Console.WriteLine("cross1.count" +cross1.Count);
          //  Console.WriteLine("a1=" + a1);
            //限制大小,判斷層數
            int hight1 = cross1[a1].High;
            int hight2 = cross2[b1].High;



            //判斷要交換的node個數
            string p1 = cross1[a1].Cross_PostOrder_1(cross1[a1]);
            cross1[a1].postorder_path = "";
            string p2 = cross2[b1].Cross_PostOrder_2(cross2[b1]);
            cross2[b1].postorder_path = "";
            int c1 = Cross_PostOrder_list_1.Count;
            int c2 = Cross_PostOrder_list_2.Count;
            //renew Cross_Postorder_1和Cross_Postorder_2
            create_tree.Node.renew_Cross_Postorder_1(Cross_PostOrder_list_1[0]);
            create_tree.Node.renew_Cross_Postorder_2(Cross_PostOrder_list_2[0]);




            //可以建立幾層,幾個node
            double num1 = Math.Pow(2, (create_tree.Max_hight - cross1[a1].High + 1)) - 1;//cross1可以建立幾個node
            double num2 = Math.Pow(2, (create_tree.Max_hight - cross2[b1].High + 1)) - 1;//cross2可以建立幾個node


            int c = 1;
            while (c2 > num1 || c1 > num2)//交配後會超出層數,無法交配
            {
                
                //Console.WriteLine("重抽  " + "hight1=" + hight1 + "  hight2=" + hight2+"  c1有="+c1+"個"+ 
                //    "  c2有=" + c2 + "個"+"  num1可以"+num1+"個" + "  num2可以" + num2 + "個");
                a1 = rand.Next(1, cross1.Count);
                hight1 = cross1[a1].High;
                b1 = rand.Next(1, cross2.Count);
                hight2 = cross2[b1].High;

                p1 = cross1[a1].Cross_PostOrder_1(cross1[a1]);
                cross1[a1].postorder_path = "";
                p2 = cross2[b1].Cross_PostOrder_2(cross2[b1]);
                cross2[b1].postorder_path = "";
                c1 = Cross_PostOrder_list_1.Count;
                c2 = Cross_PostOrder_list_2.Count;
                //renew Cross_Postorder_1和Cross_Postorder_2
                create_tree.Node.renew_Cross_Postorder_1(Cross_PostOrder_list_1[0]);
                create_tree.Node.renew_Cross_Postorder_2(Cross_PostOrder_list_2[0]);

                num1 = Math.Pow(2, (create_tree.Max_hight - cross1[a1].High + 1)) - 1;//cross1可以建立幾個node
                num2 = Math.Pow(2, (create_tree.Max_hight - cross2[b1].High + 1)) - 1;//cross2可以建立幾個node

                if (c == 100)
                {
                    child1 = cross1;
                    child2 = cross2;
                  // Console.WriteLine("交配100次不成功,不交配了!");
                    return;
                }

                c++;
            }



            //while ((hight1 - 1) + (create_tree.Max_hight - hight2 + 1) > create_tree.Max_hight)//a1重抽
            //{
            //     a1 = rand.Next(1, cross1.Count - 1);
            //     hight1 = cross1[a1].High;
            //     Console.WriteLine("重抽       "+ "hight1=" + hight1 + "       hight2=" + hight2);
            //}


            //while ((hight2 - 1) + (create_tree.Max_hight - hight1 + 1) > create_tree.Max_hight)//a2重抽
            //{
            //    b1 = rand.Next(1, cross2.Count - 1);
            //    hight2 = cross2[b1].High;
            //    Console.WriteLine("重抽       " + "hight1=" + hight1 + "       hight2=" + hight2);
            //}


            ////交換對方的hight
            //int temp = hight1;
            //hight1 = hight2;
            //hight2 = temp;
            //cross1[a1].High = hight1;
            //cross2[b1].High = hight2;

            



            string s1 = cross1[a1].Cross_PostOrder_1(cross1[a1]);
            cross1[a1].postorder_path = "";
            string s2 = cross2[b1].Cross_PostOrder_2(cross2[b1]);
            cross2[b1].postorder_path = "";

            


            //Console.WriteLine("1st目標節點是node:" + cross1[a1].Action);
            //Console.WriteLine("2nd目標節點是node:" + cross2[b1].Action);

            //Console.WriteLine("1st要交換的節點子樹有字串:" + s1);
            //Console.WriteLine("2nd要交換的節點子樹有字串:" + s2);

            //Console.WriteLine("1st要交換的節點子樹是node:");
            //foreach (Node n in Cross_PostOrder_list_1)
            //{
            //    Console.WriteLine(n.Action);
            //}

            //Console.WriteLine("2nd要交換的節點子樹是node:");
            //foreach (Node n in Cross_PostOrder_list_2)
            //{
            //    Console.WriteLine(n.Action);
            //}


            Node a1_copy = new Node(cross1[a1].ID, cross1[a1].Parent, cross1[a1].Left, cross1[a1].Right,
                            cross1[a1].High, cross1[a1].TERorOP, cross1[a1].Action);//複製1st目標節點

            Node b1_copy = new Node(cross2[b1].ID, cross2[b1].Parent, cross2[b1].Left, cross2[b1].Right,
                         cross2[b1].High, cross2[b1].TERorOP, cross2[b1].Action);//複製2nd目標節點

            //找出目標是誰的Left_child或Right_child並連接上新目標_1st
            foreach (Node n in cross1)//1st要交換的
            {
                //判斷葉節點直接跳過迴圈
                if (n.Left == null && n.Right == null)//葉節點
                {
                    //
                }
                else if (n.Left != null && n.Right != null)
                { //左右子節點都有

                    //有找到
                    if (n.Left.ID == a1_copy.ID)//左子節點id=目標節點id
                    {
                        n.Left = b1_copy;//b1_copy
                      //  n.Children.Add(b1_copy);//
                        b1_copy.Parent = n;//
                      //  b1_copy.High = n.High + 1;//設定子代的hight
                    }
                    else if (n.Right.ID == a1_copy.ID)//右子節點id=目標節點id
                    {
                        n.Right = b1_copy;//
                     //   n.Children.Add(b1_copy);//
                        b1_copy.Parent = n;//
                      //  b1_copy.High = n.High + 1;//設定子代的hight
                    }

                    //沒找到
                    else
                    {
                        //
                    }
                }//else if
                else   //只有一個子節點
                {
                    
                    if (n.Left != null)//有左節點
                    {
                        if (n.Left.ID == a1_copy.ID)
                        {//左子節點id=目標節點id
                            n.Left = b1_copy;//
                         //   n.Children.Add(b1_copy);//
                            b1_copy.Parent = n;//
                          //  b1_copy.High = n.High + 1;//設定子代的hight
                        }
                    }
                    else if (n.Right != null) //有右節點
                    {
                        if (n.Right.ID == a1_copy.ID)
                        {//右子節點id=目標節點id
                            n.Right = b1_copy;//
                         //   n.Children.Add(b1_copy);//
                            b1_copy.Parent = n;//
                          //  b1_copy.High = n.High + 1;//設定子代的hight

                        }
                    }
                    //沒找到
                    else
                    {
                        //
                    }

                }


            }
            //找出目標是誰的Left_child或Right_child並連接上新目標_2nd
            foreach (Node n in cross2)//2nd要交換的(被交換)
            {
                //判斷葉節點直接跳過迴圈
                if (n.Left == null && n.Right == null)//葉節點
                {
                    //
                }
                else if (n.Left != null && n.Right != null)
                { //左右子節點都有

                    //有找到
                    if (n.Left.ID == b1_copy.ID)//左子節點id=目標節點id
                    {
                        n.Left = a1_copy;//a1_copy
                      //  n.Children.Add(a1_copy);//
                        a1_copy.Parent = n;//
                      //  a1_copy.High = n.High + 1;//設定子代的hight
                    }
                    else if (n.Right.ID == b1_copy.ID)//右子節點id=目標節點id
                    {
                        n.Right = a1_copy;//
                       // n.Children.Add(a1_copy);//
                        a1_copy.Parent = n;//
                      //  a1_copy.High = n.High + 1;//設定子代的hight
                    }

                    //沒找到
                    else
                    {
                        //
                    }
                }//else if
                else   //只有一個子節點
                {


                    if (n.Left != null)//有左節點
                    {
                        if (n.Left.ID == b1_copy.ID)
                        {
                            n.Left = a1_copy;//
                         //   n.Children.Add(a1_copy);//
                            a1_copy.Parent = n;
                           // a1_copy.High = n.High + 1;//設定子代的hight
                        }


                    }
                    else if(n.Right.ID == b1_copy.ID)
                    {
                        n.Right = a1_copy;//
                      //  n.Children.Add(a1_copy);//
                        a1_copy.Parent = n;//
                       // a1_copy.High = n.High + 1;//設定子代的hight
                    }

                    else
                    {
                        //
                    }


                }


            }


            //重新設定已交換子樹的hight

            string ra = a1_copy.rebuild_pre(a1_copy);
            create_tree.Node.bst(reb);

            foreach (Node n in bst_list)
            {
                if (n.High<Max_hight)
                {
                    n.High = n.Parent.High + 1;
                }
               
            }

            reb.Clear();
            bst_list.Clear();


            ra = b1_copy.rebuild_pre(b1_copy);
            create_tree.Node.bst(reb);

            foreach (Node n in bst_list)
            {
                if (n.High < Max_hight)
                {
                    n.High = n.Parent.High + 1;
                }
                
            }
            reb.Clear();
            bst_list.Clear();

            //複製與刪除節點到List
            // Console.WriteLine("-------------交換後-------------");


            //1st
            foreach (Node n in Cross_PostOrder_list_1)//1st複製到2nd
            {   

                cross2.Add(n);//複製到2nd

                foreach (Node p in cross1.ToArray())//刪除要複製過去的
                {
                    if (n.ID == p.ID)
                    {
                        cross1.Remove(p);
                    }
                }
            }

            

            //2nd
            foreach (Node n in Cross_PostOrder_list_2)//2nd複製到1st
            {
                cross1.Add(n);//複製到1st

                foreach (Node p in cross2.ToArray())//刪除要複製過去的
                {
                    if (n.ID == p.ID)
                    {
                        cross2.Remove(p);
                    }
                }
            }

            //renew Cross_Postorder_1和Cross_Postorder_2
            create_tree.Node.renew_Cross_Postorder_1(Cross_PostOrder_list_1[0]);
            create_tree.Node.renew_Cross_Postorder_2(Cross_PostOrder_list_2[0]);



            string as1 = cross1[0].PostOrder(cross1[0]);
            cross1[0].postorder_path = "";
            string as2 = cross2[0].PostOrder(cross2[0]);
            cross2[0].postorder_path = "";

           // Console.WriteLine("1st交換後的節點子樹有post字串:" + as1);
           // Console.WriteLine("2nd交換後的節點子樹有post字串:" + as2);


            string ai1 = cross1[0].InOrder(cross1[0]);
            cross1[0].inorder_path = "";
            string ai2 = cross2[0].InOrder(cross2[0]);
            cross2[0].inorder_path = "";

           // Console.WriteLine("1st交換後的節點子樹有in字串:" + ai1);
           // Console.WriteLine("2nd交換後的節點子樹有in字串:" + ai2);


            //Console.WriteLine("1st交換後的post節點子樹是node:");
            //foreach (Node n in cross1)
            //{
            //    Console.WriteLine(n.Action);
            //}

            //Console.WriteLine("2nd交換後的post節點子樹是node:");
            //foreach (Node n in cross2)
            //{
            //    Console.WriteLine(n.Action);
            //}





            //Console.WriteLine("--------換成樹代表的value---------");

            
            tree_score.tree_node = as1;
            tree_score.Node_Evaluation();
          //  Console.WriteLine(as1 + "   value=" + tree_score.node_score);

            tree_score.tree_node = as2;
            tree_score.Node_Evaluation();
           // Console.WriteLine(as2 + "   value=" + tree_score.node_score);




            //-------------產生兩個子代----------------
            child1 = cross1;
            child2 = cross2;


        }

        public static void mutation(List<Node> mutate_population)
        {
            del_pop.Add(mutate_population);

            int a;

            //1.數值突變
            int rate;//選擇1. 或 2. 的機率

            if (mutate_population.Count == 2)//整棵樹只有兩個節點,只有一個節點能選
            {
                a = 1;
            }
            else if (mutate_population.Count == 1)
            {
                int t = rand.Next(1, Termianl.Count + 1);//從terminal隨機挑一個
                Node n = new Node(node_id+1,mutate_population[0],null,null,mutate_population[0].High+1,1,Termianl[t]);
                mutate_population[0].Left = n;
              //  mutate_population[0].Children.Add(n);//
                n.Parent = mutate_population[0];//
                mutate_population.Add(n);
                a = 1;
            }
            else if (mutate_population.Count == 0)
            {
               
                a = 0;
            }
            else
            {
                 a = rand.Next(1, mutate_population.Count - 1);//選擇突變位置(除了root)
            }


            //ternimal
            if (mutate_population[a].TERorOP == 1)
            {
                rate = rand.Next(1, 3);
                int h = mutate_population[a].High;

                //1.數值突變
                if (rate == 1 || h == create_tree.Max_hight)//抽到1或本身是最底層ternimal,不能再建立樹
                {
                    int t = rand.Next(1, Termianl.Count + 1);//從terminal隨機挑一個
                    while (mutate_population[a].Action.Equals(Termianl[t]))//重複
                    {
                        t = rand.Next(1, Termianl.Count + 1);//再挑一次
                    }
                    mutate_population[a].Action = Termianl[t];

                    add_pop.Add(mutate_population);
                }
                else if (rate == 2)
                {


                    //2.結構突變
                    //將terminal改成operator(tree越來越大)(建立一顆子樹)
                    int oper = rand.Next(1, Operator.Count + 1);//從operator隨機挑一個

                    Node r = new Node(mutate_population[a].ID, mutate_population[a].Parent, null, null, mutate_population[a].High,
                        2, Operator[oper]);//改為隨機一個operator



                    //可以建立幾層,幾個node
                    double num = Math.Pow(2, (create_tree.Max_hight - r.High + 1)) - 1;
                


                    for (int i = 0; i < ((int) num) - 1; i++) 
                    {
                        Node node = r.Selection();
                        node = node.Expand();
                    }



                    Node a1_copy = new Node(mutate_population[a].ID, mutate_population[a].Parent, mutate_population[a].Left, mutate_population[a].Right,
                            mutate_population[a].High, mutate_population[a].TERorOP, mutate_population[a].Action);//複製1st目標節點


                    //parent 連過來
                    //找出目標是誰的Left_child或Right_child並連接上新目標_1st
                    foreach (Node n in mutate_population)//1st要交換的
                    {
                        //判斷葉節點直接跳過迴圈
                        if (n.Left == null && n.Right == null)//葉節點
                        {
                            //
                        }
                        else if (n.Left != null && n.Right != null)
                        { //左右子節點都有

                            //有找到
                            if (n.Left.ID == a1_copy.ID)//左子節點id=目標節點id
                            {

                                n.Left = r;//
                               // n.Children.Add(r);//
                                r.Parent = n;//


                            }
                            else if (n.Right.ID == a1_copy.ID)//右子節點id=目標節點id
                            {
     
                                n.Right = r;//
                             //   n.Children.Add(r);//
                                r.Parent = n;//

                            }

                            //沒找到
                            else
                            {
                                //
                            }
                        }//else if
                        else   //只有一個子節點
                        {

                            if (n.Left != null)//有左節點
                            {
                                if (n.Left.ID == a1_copy.ID)
                                {//左子節點id=目標節點id
                          
                                    n.Left = r;//
                                 //   n.Children.Add(r);//
                                    r.Parent = n;//

                                }
                            }
                            else if (n.Right != null) //有右節點
                            {
                                if (n.Right.ID == a1_copy.ID)
                                {//右子節點id=目標節點id
                                
                                    n.Right = r;//
                                  //  n.Children.Add(r);//
                                    r.Parent = n;//

                                }
                            }
                            //沒找到
                            else
                            {
                                //
                            }

                        }


                    }

                }
                else
                {
                    Console.WriteLine("突變率錯誤");
                }

            }

            //operator
            else if (mutate_population[a].TERorOP == 2)
            {
                rate = rand.Next(1, 3);

                //1.數值突變
                if (rate == 1)
                {
                    int t = rand.Next(1, Operator.Count + 1);//從terminal隨機挑一個
                    while (mutate_population[a].Action.Equals(Operator[t]))//重複
                    {
                        t = rand.Next(1, Operator.Count + 1);//再挑一次
                    }
                    mutate_population[a].Action = Operator[t];
                    add_pop.Add(mutate_population);
                }

                //2.結構突變
                //將operator改成terminal(tree越來越小)
                else if (rate == 2)
                {
                    Node a1_copy = new Node(mutate_population[a].ID, mutate_population[a].Parent, mutate_population[a].Left, mutate_population[a].Right,
                            mutate_population[a].High, mutate_population[a].TERorOP, mutate_population[a].Action);//複製1st目標節點

                    //找出目標是誰的Left_child或Right_child並連接上新目標_1st
                    foreach (Node n in mutate_population)//1st要交換的
                    {
                        //判斷葉節點直接跳過迴圈
                        if (n.Left == null && n.Right == null)//葉節點
                        {
                            //
                        }
                        else if (n.Left != null && n.Right != null)
                        { //左右子節點都有

                            //有找到
                            if (n.Left.ID == a1_copy.ID)//左子節點id=目標節點id
                            {
                               
                                int t = rand.Next(1, Termianl.Count + 1);//從terminal隨機挑一個
                                Node c = new Node(mutate_population[a].ID, mutate_population[a].Parent, mutate_population[a].Left, mutate_population[a].Right,
                                            mutate_population[a].High,1 ,Termianl[t]);//複製1st目標節點

                                n.Left = c;//
                             //   n.Children.Add(c);//
                                c.Parent = n;//
                                

                            }
                            else if (n.Right.ID == a1_copy.ID)//右子節點id=目標節點id
                            {
                                int t = rand.Next(1, Termianl.Count + 1);//從terminal隨機挑一個
                                Node c = new Node(mutate_population[a].ID, mutate_population[a].Parent, mutate_population[a].Left, mutate_population[a].Right,
                                            mutate_population[a].High, 1, Termianl[t]);//複製1st目標節點

                                n.Right = c;//
                              //  n.Children.Add(c);//
                                c.Parent = n;//
                                
                            }

                            //沒找到
                            else
                            {
                                //
                            }
                        }//else if
                        else   //只有一個子節點
                        {

                            if (n.Left != null)//有左節點
                            {
                                if (n.Left.ID == a1_copy.ID)
                                {//左子節點id=目標節點id
                                    int t = rand.Next(1, Termianl.Count + 1);//從terminal隨機挑一個
                                    Node c = new Node(mutate_population[a].ID, mutate_population[a].Parent, mutate_population[a].Left, mutate_population[a].Right,
                                                mutate_population[a].High, 1, Termianl[t]);//複製1st目標節點

                                    n.Left = c;//
                                 //   n.Children.Add(c);//
                                    c.Parent = n;//
                                   
                                }
                            }
                            else if (n.Right != null) //有右節點
                            {
                                if (n.Right.ID == a1_copy.ID)
                                {//右子節點id=目標節點id
                                    int t = rand.Next(1, Termianl.Count + 1);//從terminal隨機挑一個
                                    Node c = new Node(mutate_population[a].ID, mutate_population[a].Parent, mutate_population[a].Left, mutate_population[a].Right,
                                                mutate_population[a].High, 1, Termianl[t]);//複製1st目標節點

                                    n.Right = c;//
                                 //   n.Children.Add(c);//
                                    c.Parent = n;//
                                   
                                }
                            }
                            //沒找到
                            else
                            {
                                //
                            }

                        }


                    }


                    //把目標節點子樹刪除
                    string s1 = (mutate_population[a].Cross_PostOrder_1((mutate_population[a])));
                    mutate_population[a].postorder_path = "";


                    //1st
                    foreach (Node n in Cross_PostOrder_list_1)
                    {

                        foreach (Node p in (mutate_population.ToArray()))//刪除要複製過去的
                        {
                            if (n.ID == p.ID)
                            {
                                mutate_population.Remove(p);
                                //p.clear
                            }
                        }
                    }

                    create_tree.Node.renew_Cross_Postorder_1(Cross_PostOrder_list_1[0]);
                    add_pop.Add(mutate_population);
                }

                else
                {
                    Console.WriteLine("突變率錯誤");
                }



                


            }


        }

       
        public static void fitness(List<Node> tree,int score)//算勝率，存入字典winrate
        {

            //int winrate_score =  score*3+(int)Math.Sqrt(4 * score)/15;
            int winrate_score = Math.Abs(score - 571); //根據真實勝率 (設必須最接近10204)



            //把每棵樹存入分數字典

            string qq = tree[0].rebuild_pre(tree[0]);
            tree[0].preorder_path = "";

            store_score.Clear();
            foreach (Node n in reb)//複製每代最佳樹
            {
                Node new_tree = new Node(n.ID, n.Parent, n.Left, n.Right, n.High, n.TERorOP, n.Action);
                store_score.Add(new_tree);
            }
            if (!dic_score.ContainsKey(store_score))
            {
                dic_score.Add(store_score, winrate_score);
            }
            reb.Clear();




            //菁英法

            if (winrate_score < best_difference_in_ger) //找每代最佳
            {
                best_difference_in_ger = winrate_score;
                //best_tree_in_ger = tree.ToList();

                //丟進postorder轉字串
                string s = tree[0].PostOrder(tree[0]);
                tree[0].postorder_path = "";
                //--------換成樹代表的value---------
                tree_score.tree_node = s;
                tree_score.Node_Evaluation();
                ger_best_socre = tree_score.node_score;

                string p2 = tree[0].rebuild_pre(tree[0]);
                tree[0].preorder_path = "";


                best_tree_in_ger.Clear();
                foreach (Node n in reb)//複製每代最佳樹
                {
                    Node new_tree = new Node(n.ID, n.Parent, n.Left, n.Right, n.High, n.TERorOP, n.Action);
                    best_tree_in_ger.Add(new_tree);
                }
               
                reb.Clear();

            }
            else if (winrate_score > best_difference_in_ger && winrate_score < second_difference_in_ger)//每代次佳
            {
                second_difference_in_ger = winrate_score;
                second_tree_in_ger = tree.ToList();

                //丟進postorder轉字串
                string s = tree[0].PostOrder(tree[0]);
                tree[0].postorder_path = "";
                //--------換成樹代表的value---------
                tree_score.tree_node = s;
                tree_score.Node_Evaluation();
                ger_second_socre = tree_score.node_score;


                string p2 = tree[0].rebuild_pre(tree[0]);
                tree[0].preorder_path = "";

                second_tree_in_ger.Clear();
                foreach (Node n in reb)//複製每代次佳樹
                {
                    Node new_tree = new Node(n.ID, n.Parent, n.Left, n.Right, n.High, n.TERorOP, n.Action);
                    second_tree_in_ger.Add(new_tree);
                }
                reb.Clear();

            }



            if (winrate_score > poor1_difference_in_ger) //找每代最差
            {
                poor1_difference_in_ger = winrate_score;
                poor1_tree_in_ger = tree.ToList();

                //丟進postorder轉字串
                string s = tree[0].PostOrder(tree[0]);
                tree[0].postorder_path = "";
                //--------換成樹代表的value---------
                tree_score.tree_node = s;
                tree_score.Node_Evaluation();
                // ger_best_socre = tree_score.node_score;


                //string p2 = tree[0].rebuild_pre(tree[0]);
                //tree[0].preorder_path = "";

                //poor1_tree_in_ger.Clear();
                //foreach (Node n in reb)//複製每代最差
                //{
                //    Node new_tree = new Node(n.ID, n.Parent, n.Left, n.Right, n.High, n.TERorOP, n.Action);
                //    poor1_tree_in_ger.Add(new_tree);
                //}
                //reb.Clear();

            }
            else if (winrate_score < poor1_difference_in_ger && winrate_score > poor2_difference_in_ger)
            {
                poor2_difference_in_ger = winrate_score;
               poor2_tree_in_ger = tree.ToList();

                //丟進postorder轉字串
                string s = tree[0].PostOrder(tree[0]);
                tree[0].postorder_path = "";
                //--------換成樹代表的value---------
                tree_score.tree_node = s;
                tree_score.Node_Evaluation();
                //ger_second_socre = tree_score.node_score;

            }
            else if (winrate_score < poor2_difference_in_ger && winrate_score > poor3_difference_in_ger)
            {
                poor3_difference_in_ger = winrate_score;
                poor3_tree_in_ger = tree.ToList();

                //丟進postorder轉字串
                string s = tree[0].PostOrder(tree[0]);
                tree[0].postorder_path = "";
                //--------換成樹代表的value---------
                tree_score.tree_node = s;
                tree_score.Node_Evaluation();
                //ger_second_socre = tree_score.node_score;

            }
            else if (winrate_score < poor3_difference_in_ger && winrate_score > poor4_difference_in_ger)
            {
                poor4_difference_in_ger = winrate_score;
                poor4_tree_in_ger = tree.ToList();

                //丟進postorder轉字串
                string s = tree[0].PostOrder(tree[0]);
                tree[0].postorder_path = "";
                //--------換成樹代表的value---------
                tree_score.tree_node = s;
                tree_score.Node_Evaluation();
                //ger_second_socre = tree_score.node_score;

            }

            if (winrate_score < best_difference) //找最佳
            {
                best_difference = winrate_score;
                //best_tree = tree.ToList();



                //丟進postorder轉字串
                string s = tree[0].PostOrder(tree[0]);
                tree[0].postorder_path = "";
                string si = tree[0].InOrder(tree[0]);
                tree[0].inorder_path = "";
                //--------換成樹代表的value---------
                tree_score.tree_node = s;
                tree_score.Node_Evaluation();
                best_score = tree_score.node_score;
                best_post = s;
                best_in = si;




                string p2 = tree[0].rebuild_pre(tree[0]);
                tree[0].preorder_path = "";

                best_tree.Clear();
                foreach (Node n in reb)//複製最佳樹
                {
                    Node new_tree = new Node(n.ID, n.Parent, n.Left, n.Right, n.High, n.TERorOP, n.Action);
                    best_tree.Add(new_tree);
                }
                reb.Clear();


            }
            else if (winrate_score > best_difference && winrate_score < second_difference) //找次佳
            {

                second_difference = winrate_score;
               // second_tree = tree.ToList();

                //丟進postorder轉字串
                string s = tree[0].PostOrder(tree[0]);
                tree[0].postorder_path = "";
                //--------換成樹代表的value---------
                tree_score.tree_node = s;
                tree_score.Node_Evaluation();
                second_score = tree_score.node_score;




                string p2 = tree[0].rebuild_pre(tree[0]);
                tree[0].preorder_path = "";

                second_tree.Clear();
                foreach (Node n in reb)//複製次佳樹
                {
                    Node new_tree = new Node(n.ID, n.Parent, n.Left, n.Right, n.High, n.TERorOP, n.Action);
                    second_tree.Add(new_tree);
                }
                reb.Clear();
                
            }

            ////fitness越小越好

            //if (!tem_rate.ContainsKey(tree[0])) //建立機率字典
            //{
            //    //dic = new Dictionary<int, List<Node>>(i, tree);
            //    tem_rate.Add(tree[0],  winrate_score);

            //}

            //fitness_sum += winrate_score; //加入futness_sum








            ////firness愈大愈好

            //int range1 = fitness_sum + 1; //此個體的fintess所佔的機率範圍,下界
            //int range2 = fitness_sum + winrate_score;//上界

            //for (int i = range1; i <= range2; i++)
            //{
            //    if (!selection_rate.ContainsKey(i)) //建立機率字典
            //    {
            //        //dic = new Dictionary<int, List<Node>>(i, tree);
            //        selection_rate.Add(i, tree[0]);
            //    }
            //}


            //fitness_sum += winrate_score; //加入futness_sum

            ////if (!tree_fitness.ContainsKey(tree)) //若不在tree字典中，建立fitness字典
            ////{
            ////    tree_fitness.Add(tree, winrate_score);
            ////}


            //if (winrate_score > best_score) //找最佳
            //{
            //    best_score = winrate_score;
            //    best_tree = tree;


            //}
            //else if (winrate_score < best_score && winrate_score > second_score) //找次佳//找次佳
            //{
            //    second_score = winrate_score;
            //    second_tree = tree;

            //}










            // Console.WriteLine("winrate=" + winrate_score);

            //fitness越小越好(輪盤)


            //if (!tem_rate.ContainsKey(tree[0])) //建立機率字典
            //{
            //    //dic = new Dictionary<int, List<Node>>(i, tree);
            //    tem_rate.Add(tree[0], (decimal)(1 / winrate_score));//存倒數

            //    Console.WriteLine("1/winrate=" + 1m/winrate_score);
            //}


            //fitness_sum += winrate_score; //加入futness_sum





        }

       
        

    }
}

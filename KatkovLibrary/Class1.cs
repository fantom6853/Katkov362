using KatkovLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Net.Security;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace KatkovLibrary
{
    public class Class1
    {
        public static NpgsqlConnection Connection { get; set; }
        public static ObservableCollection<Role> Roles { get; set; }
        public static ObservableCollection<Group> Groups { get; set; }
        public static ObservableCollection<Quest> Questions { get; set; }
        public static ObservableCollection<Questionnaire> Questionnaires { get; set; }
        public static ObservableCollection<Questionnairetype> Questionnairetypes { get; set; }
        public static ObservableCollection<Answer> Answers { get; set; }
        public static ObservableCollection<User> Users { get; set; }
        public static ObservableCollection<Quest> QuestsinQuestionnaires { get; set; }
        public static ObservableCollection<AnswerOptions> answerOptions { get; set; }
        public static ObservableCollection<string> variants { get; set; }
        public Class1()
        {
            NpgsqlCommand command = new NpgsqlCommand();
            Roles = new ObservableCollection<Role>();
            Groups = new ObservableCollection<Group>();
            Questions = new ObservableCollection<Quest>();
            Questionnaires = new ObservableCollection<Questionnaire>();
            Questionnairetypes = new ObservableCollection<Questionnairetype>();
            Answers = new ObservableCollection<Answer>();
            Users = new ObservableCollection<User>();
            QuestsinQuestionnaires = new ObservableCollection<Quest>();
            answerOptions = new ObservableCollection<AnswerOptions>();
            variants = new ObservableCollection<string>();
            command.Connection = Connection;
            
            ListsLoad();
        }
        public static int Auth(string login,string password)
        {
            object res;
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = Connection;
            command.CommandText = "Select id FROM public.users WHERE login = @a and password = @b";
            command.Parameters.AddWithValue("@a", login);
            command.Parameters.AddWithValue("@b", password);
            try
            {
                res = command.ExecuteScalar();
                if (res != null)
                {
                    return (int)res;
                }
            }
            catch {}
            return (0);
        }
        public static void ListsLoad()
        {
            Users.Clear();
            Questions.Clear();
            Questionnaires.Clear();
            Answers.Clear();
            Groups.Clear();
            Questionnairetypes.Clear();
            Roles.Clear();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = Connection;
            command.CommandText = "SELECT id,login,password,name,surename,patronimic,role,groups FROM public.users Where groups is not null";
            var result = command.ExecuteReader();

            if (result == null) return;
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Users.Add(new User(
                        result.GetInt32(0),
                        result.GetString(1),
                        result.GetString(2),
                        result.GetString(3),
                        result.GetString(4),
                        result.GetString(5),
                        result.GetInt32(6),
                        result.GetInt32(7)));
                }

            }
            result.Close();
            command.CommandText = "SELECT id,name FROM public.groups";
            result = command.ExecuteReader();

            if (result == null) return;
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Groups.Add(new Group(
                        result.GetInt32(0),
                        result.GetString(1)));
                }

            }
            result.Close();
            command.CommandText = "SELECT id,name FROM public.roles";
            result = command.ExecuteReader();

            if (result == null) return;
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Roles.Add(new Role(
                        result.GetInt32(0),
                        result.GetString(1)));
                }

            }
            result.Close();
            command.CommandText = "SELECT id,teacher,name FROM public.questionnaire";
            result = command.ExecuteReader();

            if (result == null) return;
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Questionnaires.Add(new Questionnaire(
                        result.GetInt32(0),
                        result.GetInt32(1),
                        result.GetString(2)));
                }

            }
            result.Close();
            command.CommandText = "SELECT id,name FROM public.questtype";
            result = command.ExecuteReader();

            if (result == null) return;
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Questionnairetypes.Add(new Questionnairetype(
                        result.GetInt32(0),
                        result.GetString(1)));
                }

            }
            result.Close();
            command.CommandText = "SELECT id,questionnaire,type,text,answeroptions FROM public.quest";
            result = command.ExecuteReader();

            if (result == null) return;
            if (result.HasRows)
            {
                var options = new JsonSerializerOptions();
                while (result.Read())
                {
                    try
                    {
                        answerOptions.Add( JsonSerializer.Deserialize<AnswerOptions>(result.GetString(4), options));
                        Questions.Add(new Quest(
                        result.GetInt32(0),
                        result.GetInt32(1),
                        result.GetInt32(2),
                        result.GetString(3),
                        result.GetString(4)));
                    }
                    catch
                    {
                        string nullstring = null;
                        Questions.Add(new Quest(
                        result.GetInt32(0),
                        result.GetInt32(1),
                        result.GetInt32(2),
                        result.GetString(3),
                        nullstring));
                        
                    }
                    
                }

            }
            result.Close();
            command.CommandText = "SELECT id,student,quest,answer FROM public.answer";
            result = command.ExecuteReader();

            if (result == null) return;
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Answers.Add(new Answer(
                        result.GetInt32(0),
                        result.GetInt32(1),
                        result.GetInt32(2),
                        result.GetString(3)));
                }

            }
            result.Close();
        }
        public static void StudentAdd(string login, string password,string name,string surename,string patronimic,int group)
        {
            int role = 2;
            NpgsqlCommand command = new NpgsqlCommand();
            if (patronimic == "0")
            {
                command.Connection = Connection;
                command.CommandText = "INSERT INTO public.users (login,password,name,surename,role,groups) VALUES (@a,@b,@c,@d,@f,@g)";
                command.Parameters.AddWithValue("@a", login);
                command.Parameters.AddWithValue("@b", password);
                command.Parameters.AddWithValue("@c", name);
                command.Parameters.AddWithValue("@d", surename);
                command.Parameters.AddWithValue("@f", role);
                command.Parameters.AddWithValue("@g", group);
                command.ExecuteNonQuery();
            }
            else
            {
                command.Connection = Connection;
                command.CommandText = "INSERT INTO public.users (login,password,name,surename,patronimic,role,groups) VALUES (@a,@b,@c,@d,@e,@f,@g)";
                command.Parameters.AddWithValue("@a", login);
                command.Parameters.AddWithValue("@b", password);
                command.Parameters.AddWithValue("@c", name);
                command.Parameters.AddWithValue("@d", surename);
                command.Parameters.AddWithValue("@e", patronimic);
                command.Parameters.AddWithValue("@f", role);
                command.Parameters.AddWithValue("@g", group);
                command.ExecuteNonQuery();
            }
        }
        public static int TeacherCheck(int id)
        {
            object res;
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = Connection;
            command.CommandText = "Select role FROM public.users WHERE id = @a";
            command.Parameters.AddWithValue("@a", id);
            try
            {
                res = command.ExecuteScalar();
                if (res != null)
                {
                    return (int)res;
                }
            }
            catch
            {
            }
            return (0);
        }
        public static void questionaireAdd(string name, string login)
        {
            object res;
            int teacher = 0;
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = Connection;
            command.CommandText = "Select id From public.users Where login = @a";
            command.Parameters.AddWithValue("@a", login);
            try
            {
                res = command.ExecuteScalar();
                if (res != null)
                {
                    teacher = (int)res;
                }
            }
            catch
            {
                return;
            }
            command.Parameters.Clear();
            command.Connection = Connection;
            command.CommandText = "INSERT INTO public.questionnaire (teacher,\"name\") VALUES (@b,@a)";
            command.Parameters.AddWithValue("@a", name);
            command.Parameters.AddWithValue("@b", teacher);
            command.ExecuteNonQuery();
            return;
        }
        public static void QuestAdd(int id,int type,string text,string answeroptions)
        {
            if(answeroptions.Trim().Length == 0)
            {
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = Connection;
                command.CommandText = "INSERT INTO public.quest (questionnaire,type,text,answeroptions) VALUES (@a,@b,@c,@d)";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@a", id);
                command.Parameters.AddWithValue("@b", type);
                command.Parameters.AddWithValue("@c", text);
                command.Parameters.AddWithValue("@d", DBNull.Value);
                command.ExecuteNonQuery();
            }
            else
            {
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = Connection;
                command.CommandText = "INSERT INTO public.quest (questionnaire,type,text,answeroptions) VALUES (@a,@b,@c,@d)";
                command.Parameters.AddWithValue("@a", id);
                command.Parameters.AddWithValue("@b", type);
                command.Parameters.AddWithValue("@c", text);
                command.Parameters.AddWithValue("@d", NpgsqlDbType.Json,answeroptions);
                command.ExecuteNonQuery();
            }
            Class1.answerOptions.Clear();
            return;

        }
        public static void IdQuest(int id)
        {
            QuestsinQuestionnaires.Clear();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = Connection;
            command.CommandText = "SELECT id,questionnaire,type,text,answeroptions FROM public.quest Where questionnaire = @a";
            command.Parameters.AddWithValue("@a", id);
            var result = command.ExecuteReader();
            if (result == null) return;
            if (result.HasRows)
            {
                while (result.Read())
                {
                    try
                    {
                        QuestsinQuestionnaires.Add(new Quest(
                        result.GetInt32(0),
                        result.GetInt32(1),
                        result.GetInt32(2),
                        result.GetString(3),
                        result.GetString(4)));
                    }
                    catch
                    {
                        string nullstring = null;
                        QuestsinQuestionnaires.Add(new Quest(
                        result.GetInt32(0),
                        result.GetInt32(1),
                        result.GetInt32(2),
                        result.GetString(3),
                        nullstring));
                    }
                    
                }
                command.Parameters.Clear();
                result.Close();

            }
        }
        public static void QuestAnswerLoad(int id)
        {
            answerOptions.Clear();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = Connection;
            command.CommandText = "SELECT answeroptions FROM public.quest WHERE id =@a";
            command.Parameters.AddWithValue("@a",id);
            var result = command.ExecuteReader();

            if (result == null) return;
            if (result.HasRows)
            {
                var options = new JsonSerializerOptions();
                while (result.Read())
                {
                    try
                    {
                        answerOptions.Add(JsonSerializer.Deserialize<AnswerOptions>(result.GetString(0), options));
                    }
                    catch
                    {
                    }
                }
            }
            result.Close();
        }
        
           
        
        
        

        public static void Connect(string host, int port, string user, string pass, string dbname)
        {
            string cs = string.Format("Server={0};Port={1};User ID={2};Password={3};DataBase={4}", host, port, user, pass, dbname);
            Connection = new NpgsqlConnection(cs);
            Connection.Open();
        }
    }
}

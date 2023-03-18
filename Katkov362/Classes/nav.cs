using Katkov362.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katkov362.Classes
{
    public class nav
    {
        private static Auth auth;
        private static TeacherPage teacherPage;
        private static CreateQuestion createQuestion;
        private static GiveQuestion giveQuestion;
        private static AddStudents addStudents;
        private static EditQuestion editQuestion;
        private static CreateQuest createQuest;
        public static Auth Auth
        {
            get
            {
                if(auth == null)
                {
                    auth = new Auth();
                }
                return auth;
            }
        }
        public static CreateQuest CreateQuest
        {
            get
            {
                if(createQuest == null)
                {
                    createQuest = new CreateQuest();
                    
                }
                return createQuest;
            }
        }
        public static TeacherPage TeacherPage
        {
            get
            {
                if(teacherPage == null)
                {
                    teacherPage= new TeacherPage();
                }
                return teacherPage;
            }
        }
        public static CreateQuestion CreateQuestion
        {
            get
            {
                if(createQuestion == null)
                {
                    createQuestion = new CreateQuestion();
                }
                return createQuestion;
            }
        }
        public static GiveQuestion GiveQuestion
        {
            get
            {
                if(giveQuestion== null)
                {
                    giveQuestion = new GiveQuestion();
                }
                return giveQuestion;
            }
        }
        public static AddStudents AddStudents
        {
            get
            {
                if(addStudents == null)
                {
                    addStudents = new AddStudents();
                }
                return addStudents;
            }
        }
        public static EditQuestion EditQuestion
        {
            get
            {
                if(editQuestion == null)
                {
                    editQuestion = new EditQuestion();
                }
                return editQuestion;
            }
        }
    }
}

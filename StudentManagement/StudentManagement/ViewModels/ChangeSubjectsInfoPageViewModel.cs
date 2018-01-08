using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using StudentManagement.Interfaces;
using StudentManagement.Models;
using StudentManagement.ViewModels.Base;

namespace StudentManagement.ViewModels
{
    public class ChangeSubjectsInfoPageViewModel : ViewModelBase
    {
        private ObservableCollection<Subject> _subjects;
        public ObservableCollection<Subject> Subjects
        {
            get => _subjects;
            set => SetProperty(ref _subjects, value);
        }

        public ICommand AddCommand { get; set; }
        

        public ChangeSubjectsInfoPageViewModel(INavigationService navigationService, IPageDialogService dialogService,
            ISQLiteHelper sqLiteHelper)
            : base(navigationService, dialogService, sqLiteHelper)
        {
            PageTitle = "Thay đổi thông tin môn học";
            AddCommand = new DelegateCommand(AddExecute);
            Subjects = new ObservableCollection<Subject>(Database.GetList<Subject>(s => s.Id > 0));
        }

        public void EditExecute(Subject subject)
        {
            Dialog.DisplayAlertAsync("", subject.Name, "Ok");
        }

        public async void RemoveExecute(Subject subject)
        {
            bool isAccept = await Dialog.DisplayAlertAsync("Xóa môn học", "Bạn có chắc muốn xóa môn học này?", "Có", "Không");
            if (isAccept)
            {
                var score = Database.Get<Score>(s=>s.SubjectId == subject.Id);

                if (score != null)
                    await Dialog.DisplayAlertAsync("Thông báo", "Môn học này đang có học sinh học, không thể xóa", "OK");
                else
                {
                    Subjects.Remove(subject);
                    Database.Delete(subject);
                    await Dialog.DisplayAlertAsync("Thông báo", "Xóa môn học thành công", "OK");
                }
            }
        }

        public void AddExecute()
        {

        }
    }
}

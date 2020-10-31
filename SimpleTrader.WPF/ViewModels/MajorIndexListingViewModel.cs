using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.ViewModels
{
    public class MajorIndexListingViewModel : ViewModelBase
    {
        private readonly IMajorIndexService majorIndexService;

        private MajorIndex nasdaq;
        public MajorIndex Nasdaq
        {
            get
            {
                return nasdaq;
            }
            set
            {
                nasdaq = value;
                OnPropertyChanged(nameof(Nasdaq));
            }
        }
        private MajorIndex sP500;
        public MajorIndex SP500
        {
            get
            {
                return sP500;
            }
            set
            {
                sP500 = value;
                OnPropertyChanged(nameof(SP500));
            }
        }

        private MajorIndex dowJones;
        public MajorIndex DowJones
        {
            get
            {
                return dowJones;
            }
            set
            {
                dowJones = value;
                OnPropertyChanged(nameof(DowJones));
            }
        }

        private MajorIndexListingViewModel(IMajorIndexService majorIndexService)
        {
            this.majorIndexService = majorIndexService;
        }

        public static MajorIndexListingViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            var majorIndexListingViewModel = new MajorIndexListingViewModel(majorIndexService);
            majorIndexListingViewModel.LoadMajorIndexesAsync();
            return majorIndexListingViewModel;
        }

        public void LoadMajorIndexesAsync()
        {
            majorIndexService.GetMajorIndex(MajorIndexType.Nasdaq).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Nasdaq = task.Result;
                }
            });

            majorIndexService.GetMajorIndex(MajorIndexType.SP500).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    SP500 = task.Result;
                }
            });

            majorIndexService.GetMajorIndex(MajorIndexType.DowJones).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    DowJones = task.Result;
                }
            });
        }
    }
}

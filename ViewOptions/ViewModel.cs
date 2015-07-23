using Bizmonger.Patterns;
using Core;
using DataAccessMediator;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ViewMenu
{
    public partial class ViewModel : ViewModelBase
    {
        #region Members
        MessageBus _messagebus = MessageBus.Instance;
        #endregion

        public ViewModel()
        {
            _messagebus.Subscribe(Messages.REQUEST_SET_CLIPBOARD, obj => CopyMade = true);
            _messagebus.Subscribe(Messages.CONTENT_SELECTED, OnContentSelected);
            _messagebus.Subscribe(Messages.REQUEST_LOAD_CONTENT, OnLoadContent);
        }

        Content _content1 = null;
        public Content Content1
        {
            get
            {
                return _content1;
            }
            set
            {
                if (_content1 != value)
                {
                    _content1 = value;
                    OnPropertyChanged();
                }
            }
        }

        Content _content2 = null;
        public Content Content2
        {
            get
            {
                return _content2;
            }
            set
            {
                if (_content2 != value)
                {
                    _content2 = value;
                    OnPropertyChanged();
                }
            }
        }

        Content _content3 = null;
        public Content Content3
        {
            get
            {
                return _content3;
            }
            set
            {
                if (_content3 != value)
                {
                    _content3 = value;
                    OnPropertyChanged();
                }
            }
        }

        Content _content4 = null;
        public Content Content4
        {
            get
            {
                return _content4;
            }
            set
            {
                if (_content4 != value)
                {
                    _content4 = value;
                    OnPropertyChanged();
                }
            }
        }

        bool _copyMade = false;
        public bool CopyMade
        {
            get
            {
                return _copyMade;
            }
            set
            {
                if (_copyMade != value)
                {
                    _copyMade = value;
                    OnPropertyChanged();
                }
            }
        }

        Content _selectedContent = null;
        public Content SelectedContent
        {
            get
            {
                return _selectedContent;
            }
            set
            {
                if (_selectedContent != value)
                {
                    _selectedContent = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
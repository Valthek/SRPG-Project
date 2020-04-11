using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Entities.Interfaces
{
    public interface ISelectable
    {
        void Select();
        void Deselect();
    }
}

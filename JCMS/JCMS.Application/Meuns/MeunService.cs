using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCms.Meuns
{
    public class MeunService : IMeunService
    {
        private readonly IRepository<Meun, int> _meunRepository;
        public ILogger Logger { get; set; }
        public MeunService(IRepository<Meun, int> meunRepository)
        {
            Logger = NullLogger.Instance;
            _meunRepository = meunRepository;
        }
        public List<MeunDto> GetMeunList()
        {
            List<MeunDto> MeunList = new List<MeunDto>();
            var meun = _meunRepository.GetAllList();
            MeunList = new List<MeunDto>(
                meun.MapTo<List<MeunDto>>()
                );
            List<MeunDto> NewMeunList = new List<MeunDto>();
            List<MeunDto> list = MeunList.ToList();
            foreach (var item in list)
            {
                if (item.ParentId==0)
                {
                    MeunDto dto = new MeunDto();
                    dto = item;
                    AddChildNode(MeunList, ref dto);
                    NewMeunList.Add(dto);
                } 
            }
            return NewMeunList;
        }

        public void AddChildNode(List<MeunDto> list, ref MeunDto dto)
        {
            List<MeunDto> newlist = new List<MeunDto>();
            foreach (MeunDto item in list)
            {
                if (item.ParentId == dto.Id)
                {
                    newlist.Add(item);
                    dto.children = newlist;
                }
            }
            foreach (MeunDto item in newlist)
            {
                MeunDto dt = item;
                AddChildNode(list, ref dt);

            }

        }
        public List<MeunDto> GetColumnchid(List<MeunDto> list)
        {
            try
            {
                if (list[0].ParentId != 0)
                {
                    List<MeunDto> newlist = null;
                    var data = from i in _meunRepository.GetAll()
                               select i;

                    List<MeunDto> newlit = data.MapTo<List<MeunDto>>().ToList();
                    newlit = newlit.Where(o => o.Id == list[0].ParentId).ToList();
                    if (newlit != null)
                    {
                        newlist = newlit.MapTo<List<MeunDto>>();
                        if (newlist[0].ParentId == list[0].Id)
                        {
                            return list;
                        }
                        list[0].children = newlist;
                        if (newlist[0].ParentId != null)
                        {

                            if (list[0].children.Count > 0)
                            {
                                GetColumnchid(list[0].children);
                            }

                        }
                        return list;
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
            }
            return list;
        }

    }
}

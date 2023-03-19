using UniqueList;

var list = new UniqueList.UniqueList<int>();
list.Add(3, 0);
list.Add(4, 1);
list.Add(6, 2);
list.Add(3, 1);
list.Change(8, 2);
list = list;
В решении есть три проекта:
  1. DataAccessLayer: отвечает за работу с данными. В этом проекте есть два класса которые обеспечивают доступ к .json файлу используя механизм сериализации: это JSONSerializer и JSONSerializeService. И еще один класс Entity который выступает в качестве модели для хранения информации.
  2. BusinessLogicLayer: отвечает за обработку данных, то есть за выполнение вычислений и других манипуляций с данными которые после их считывания из файла уже хранятся в списке.
  3. PresentationLayer.ConsoleApp: класс отвечающий за представление,  здесь реолизировано меню где пользователь может выбирать департамент для дальнейших вычислений.

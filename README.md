# PigBomber2D

## Инструкция

___Чтобы сменить управление поменяйте в инспекторе у игрового объекта Player поле Input Reciever класса Player Movement 
Joystick Input - для мобильных устройств, Keyboard Input - для пк.___

## Комментарий

_В целях экономии времени выбрал готовую реализацию A* поиска пути - но в ней нельзя (а может и можно, но надо разбираться) 
поставить Waypoint'ы, по которым двигается объект, поэтому враг частенько застревает, можно перезапустить сцену на кнопку Restart, когда такое происходит.
Лучше конечно использовать свой алгоритм, и лучше переписать класс сетки (Game Grid), определение содержимого каждой ячейки сейчас происходит через OverlapCollider, 
конечно это не хорошо и ячейки сами должны знать что в них находится ещё до начала игры. В продакшн бы так не делал :)
Задание понравилось, даже интересно что нет жёстких ограничений, можно реализовывать что угодно) Сделал всё что планировал, но добавлять ещё можно много чего._

## Использованные ассеты

- DOTween
- Cinemachine Camera
- AstarPathfinding
- Joystick Pack
 

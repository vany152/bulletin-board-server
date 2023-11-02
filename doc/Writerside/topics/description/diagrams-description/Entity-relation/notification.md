# Объявление

## Сведения

Объявления используются для доставки различной информации целевым группам пользователей в иерархии университета.
Объявление создается на одном из узлов иерархии и может быть отправлено только группам пользователей, находящихся на
уровень не выше текущего и непосредственно или опосредованно связанным с текущей группой.

## Свойства

Объявление содержит следующие свойства:

- [Текст](#текст)
- [Флаг скрытой публикации](#флаг-скрытой-публикации)
- [Флаг автоматического сокрытия](#флаг_автоматического_сокрытия)
- [Срок автоматического сокрытия](#срок-автоматического_сокрытия)
- [Флаг отложенной публикации](#флаг-отложенной-публикации)
- [Срок отложенной публикации](#срок-отложенной-публикации)
- [Флаг удаления](#флаг-удаления)
- [Момент публикации](#момент-публикации)

### Текст

Свойство текст представляет собой текстовое содержимое объявления.

### Флаг скрытой публикации

Флаг скрытой публикации определяет, скрыто ли объявление. Если флаг выставлен, объявление считается скрытым и не
отображается в общей ленте объявлений.

### Флаг автоматического сокрытия

Флаг автоматического сокрытия отражает возможность автоматического сокрытия объявления. Если флаг выставлен, объявление
скрывается по наступлении заданного срока.

При сбросе флага срок автоматического сокрытия очищается.

Объявления с выставленным флагом автоматического сокрытия на интерфейсе имеют специализированную метку. %% todo move to
api %%

### Срок автоматического сокрытия

Срок автоматического сокрытия задается для выполнения автоматического сокрытия объявления. Не задается, если флаг
автоматического сокрытия объявления не выставляется изначально и очищается в случае сброса флага автоматического
сокрытия.

Даже если в объявлении сброшен флаг автоматического сокрытия и задан срок автоматического сокрытия, объявление не
скрывается по наступлении указанного срока.

Если флаг выставлен и срок автоматического сокрытия не указан, объявление не скрывается и запись об ошибке логгируется.

На момент задания срока момент автоматического сокрытия не может наступить раньше самого момента задания срока
отложенной публикации.

### Флаг отложенной публикации

Флаг отложенной публикации отражает возможность автоматической публикации объявления по наступлении заданного срока.
Если флаг выставлен, объявление автоматически публикуется в указанный срок.

При сбросе флага срок отложенной публикации очищается.

Флаг отложенной публикации нельзя выставить или скрыть на уже опубликованном объявлении.

Объявления с выставленным флагом отложенной публикации отображаются в отдельном списке.

### Срок отложенной публикации

Срок отложенной публикации задается для выполнения отложенной публикации объявления. Не задается, если флаг отложенной
публикации объявления не выставляется изначально и очищается в случае сброса флага отложенной публикации.

Даже если в объявлении сброшен флаг отложенной публикации и задан срок отложенной публикации, объявление не публикуется
по наступлении указанного срока.

Если флаг выставлен и срок отложенной публикации не указан, объявление не публикуется и запись об ошибке логгируется.

На момент задания срока момент отложенной публикации не может наступить раньше самого момента задания срока отложенной
публикации.

### Флаг удаления

Флаг удаления публикации отражает статус объявления: если флаг выставлен, объявление считается удаленным и не
отображается ни в одном из списков приложения. Отсутствует возможность сброса флага удаления.

Возможность запроса списка удаленных объявлений не предусмотрена.

### Момент публикации

При публикации объявления на доску объявлений в фактический момент публикации записываются дата и время публикации
объявления.

Свойство не может быть очищено.

## Связи

Объявление связано со следующими сущностями:

- [Пользователь](#пользователь)
- [Группа пользователей](#группа-пользователей)
- [Категория](#категория)
- [Файл](#файл)
- [Опрос](#опрос)

### Пользователь

Объявление связано с сущность "Пользователь" отношением "Является автором" и связью один-ко-многим, что означает, что у
объявления может быть ровно один автор, а пользователь может являться автором любого количества объявлений, в том числе
нулевого.

### Категория

Объявление связано с сущностью "Категория" связью многие-ко-многим, причем как объявление может не иметь категорий, так
и категория может не относиться ни к одному объявлению.

### Группа пользователей

Объявление связано с сущность "Группа пользователей" связью многие-ко-многим, причем объявление может быть связано с
минимум одной группой пользователей, а группа пользователей может не иметь связей ни с одним объявлением.

### Файл

Объявление связано с сущностью "Файл" связью многие-ко-многим, причем объявление может содержать любое неотрицательное
количество файлов, а файл должен быть прикреплен минимум к одному объявлению.

Прикрепление файла к каждому объявлению означает наличие одной ссылки. Открепление файла от объявления означает
уничтожение одной ссылки. При уничтожении последней ссылки на файл в автоматическом порядке через заданный промежуток
времени происходит удаление файла с сервера.

Отсутствует возможность прикрепить к объявлению файлы в том случае, если к нему уже прикреплен опрос.

### Опрос

Объявление связано с сущностью "Опрос" связью один-к-одному, причем объявление может быть связано максимум с одним
опросом, а опрос должен быть связан ровно с одним объявлением.

К объявлению нельзя прикрепить опрос, если к нему прикреплено любое количество файлов.

1. Создать учетную запись на ресурсе github.com
![](/images/1GitAccount.jpg)
2. Создать на ресурсе github.com репозиторий для выполнения практической работы.

3. Создать папку для работы с Git.


![](/images/4Papka.jpg)

4. Создать локальный репозиторий в текущей папке.
```
git init
```
5. Добавьте туда пустой текстовый документ.

6. Сформируйте этот документ, создавая commit для каждого абзаца, не менее 5 абзацев.
![](/images/6first_paragraph.jpg)
![](/images/6third_paragraph.jpg)
7. Посмотреть статус текущего репозитория.
![](/images/7status.jpg)
8. Добавить файл.


![](/images/8newTXT.jpg)

9. Создать коммит, указать для него комментарий.


![](/images/9commit.jpg)

10. Посмотреть протокол коммитов.


![](/images/10Log.jpg)

11. Посмотреть изменения в файле по сравнению с последним коммитом.
```
git checkout -- first.txt
```
12. Убрать изменения относительно последнего коммита из файла.
```
git restore first.txt
```
13. Просмотреть существующие ветки.


![](/images/13branch.jpg)

14. Создать новую ветку.
```
git branch first_branch
```
15. Переключиться на другую ветку.


![](/images/15checkout.jpg)

16. Создать новую ветку и сразу же переключиться на нее.


![](/images/16checkout-b.jpg)

17. Удалить ветку.


![](/images/17delete.jpg)

18. Добавить (merge) изменения из указанной ветки в текущую.


![](/images/18merge.jpg)

19. 23 Создать конфликт.

20. 24 Посмотреть в каких файлах есть конфликты.

21. Устранить конфликты.

22. Переключиться на указанный коммит.
![](/images/22commitCheck.jpg)
23. Сделать ребазирование (rebase) текущей ветки.


![](/images/23rebase.jpg)

24. Удалить ветку.
```
git branch -d second_branch
```
25. Пропустить текущий конфликтный коммит и перейти к следующему.
```
git rebase --skip
```
26. Отправить изменения из локального репозитория для указанной ветки в удаленный (дистанционный).
![](/images/26push.jpg)
27. Забрать изменения из репозитория, для которого были созданы удаленные ветки по умолчанию.
![](/images/27pull.jpg)
28. Забрать изменения удаленной ветки из репозитория основной ветки по умолчанию.
![](/images/28push.jpg)
29. Создать копию репозитория.
![](/images/29clone.jpg)

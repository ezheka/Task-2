# Задание по Task и async/await
____
**Нужно сделать приложение которое будет записывать в файл новые строки.**

***Подробнее:***
+ Вы вводите строку, приложение записывает ее в файл
+ Есть цикл который каждые 20 секунд читает файл и выводит данные.

***Требования:***    
:no_entry_sign: Читать и писать в файл можно только в разных потоках (можно в разных тасках).    
:no_entry_sign: Нельзя использовать lock или bool для запрета чтения или записи.    
:no_entry_sign: Не должно быть ошибок чтения и записи.    
:no_entry_sign: Нельзя читать и писать в одной таске.    
:no_entry_sign: Цикл чтения не должен прерываться.    
:no_entry_sign: Нельзя использовать Coroutine или Update.

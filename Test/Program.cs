using WordHunter;

// При добавлении нового слова, его язык определяет сама программа
    // При добавлении перевода к новому слову, программа учитывает локализацию слова, к которму добавляется перевод
    // если слово английское, то соответственно можно добавить только русский перевод, и наоборот

// Поиск слова можно осуществить по идентификатору слова, либо по самому слову
// Для изменения перевода слова, нужно ввести само слово, слово-перевод которое хотим изменить и новый перевод

var lex = Application.GetApplication();
lex.CreateLexicone();
lex.FillLexicone();

Menu menu = new Menu(lex);

menu.Start();
namespace MyApplication;

public static class Utility : object
{
	public static bool IsFirstLetterPersian(string? text)
	{
	    if (string.IsNullOrWhiteSpace(text))
	    {
	        return false;
	    }
	
	    return PersianLetters.Contains(text[0]);
	}
	
	private static readonly char[] PersianLetters = new char[]
	{
	    'آ', 'ا', 'ب', 'پ', 'ت', 'ث', 'ج', 'چ', 'ح', 'خ', 'د', 'ذ', 'ر', 'ز', 'ژ', 'س', 'ش', 'ص', 'ض', 'ط', 'ظ', 'ع', 'غ', 'ف', 'ق', 'ک', 'گ', 'ل', 'م', 'ن', 'و', 'ه', 'ی', 'ي'
	};
}

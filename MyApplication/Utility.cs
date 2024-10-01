namespace MyApplication;

public static class Utility : object
{
	public static bool IsFirstLetterIsPersian(string? text)
	{
		if (string.IsNullOrWhiteSpace(value: text))
		{
			return false;
		}

		char firstCharacter = text[0];

		switch (firstCharacter)
		{
			case 'آ':
			case 'ا':
			case 'ب':
			case 'پ':
			case 'ت':
			case 'ث':
			case 'ج':
			case 'چ':
			case 'ح':
			case 'خ':
			case 'د':
			case 'ذ':
			case 'ر':
			case 'ز':
			case 'ژ':
			case 'س':
			case 'ش':
			case 'ص':
			case 'ض':
			case 'ط':
			case 'ظ':
			case 'ع':
			case 'غ':
			case 'ف':
			case 'ق':
			case 'ک':
			case 'گ':
			case 'ل':
			case 'م':
			case 'ن':
			case 'و':
			case 'ه':
			case 'ی':
			case 'ي':
			{
				return true;
			}

			default:
			{
				return false;
			}
		}
	}
}

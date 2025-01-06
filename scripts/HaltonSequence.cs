namespace GabrielGraph.scripts;



public static class HaltonSequence {
	public static float Sequence(int radix, int index) {

		float result = 0;
		float digitalWeight = 1;
		
		
		while (index > 0) {
			digitalWeight = digitalWeight / radix;
			int nominator = index % radix;
			result += nominator * digitalWeight;
			index = index / radix;
		}
		
		return result;
	}
	
	
}
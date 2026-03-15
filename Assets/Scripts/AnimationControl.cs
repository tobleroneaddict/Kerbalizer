using UnityEngine;

public class AnimationControl : MonoBehaviour
{
	public AnimationClip[] animationsKerbal;

	public AnimationClip[] expressionsAnimation;

	public Transform headTransform;

	public float timeToChangeAnimation;

	private int index;

	private int expressionAnimationIndex;

	private int currentIndexAnimation;

	private string currentAnimation;

	private bool pause;

	private float minTimeValue;

	private float maxTimeValue;

	private float valueSlider;

	private float initialtime;

	private Rect controlButtonAnimationRect;

	private Rect sliderControlAnimationRect;

	private string actionLegend;

	public GUISkin style;

	public Texture playTexture;

	public Texture pauseTexture;

	private AnimationState animationState;

	private float nativeHorizontalResolution;

	private float nativeVerticalResolution;

	public HUDEZ newHUD;

	private void Awake()
	{
		nativeHorizontalResolution = 854f;
		nativeVerticalResolution = 480f;
	}

	private void Start()
	{
		controlButtonAnimationRect = new Rect(nativeHorizontalResolution * 0.7f, nativeVerticalResolution * 0.93f, (float)pauseTexture.width * 1f, (float)pauseTexture.height * 1f);
		sliderControlAnimationRect = new Rect(nativeHorizontalResolution * 0.4f, nativeVerticalResolution * 0.95f, nativeHorizontalResolution * 0.3f, nativeVerticalResolution * 0.2f);
		index = 0;
		expressionAnimationIndex = 6;
		pause = false;
		actionLegend = "Pause";
		minTimeValue = 0f;
		maxTimeValue = 0f;
		valueSlider = 0f;
		AnimationClip[] array = animationsKerbal;
		foreach (AnimationClip animationClip in array)
		{
			animationClip.wrapMode = WrapMode.Loop;
			base.animation.AddClip(animationClip, animationClip.name);
			index++;
		}
		AnimationClip[] array2 = expressionsAnimation;
		foreach (AnimationClip animationClip2 in array2)
		{
			animationClip2.wrapMode = WrapMode.ClampForever;
			base.animation.AddClip(animationClip2, animationClip2.name);
		}
		currentAnimation = animationsKerbal[0].name;
		base.animation.Play(currentAnimation);
		initialtime = Time.time;
	}

	private void Update()
	{
		if (pause)
		{
			base.animation[currentAnimation].time = valueSlider;
		}
		if (!pause && Time.time - initialtime > timeToChangeAnimation)
		{
			ChangeAnimation();
			initialtime = Time.time;
		}
	}

	public void UIControl(string state)
	{
		if (state == "play")
		{
			pause = true;
			actionLegend = "Play";
			valueSlider = base.animation[currentAnimation].time;
			newHUD.setSilderVal(valueSlider / base.animation[currentAnimation].length);
		}
		else
		{
			pause = false;
			actionLegend = "Pause";
			valueSlider = 0f;
			newHUD.setSilderVal(valueSlider);
		}
	}

	private void ChangeAnimation()
	{
		currentIndexAnimation = Random.Range(1, index);
		currentAnimation = animationsKerbal[currentIndexAnimation].name;
		maxTimeValue = base.animation[currentAnimation].length;
		base.animation.CrossFade(currentAnimation, 0.2f);
		base.animation.Blend(expressionsAnimation[expressionAnimationIndex].name, 1f, 0f);
	}

	public void ApplyExpression(int indexAnim)
	{
		base.animation.Play(currentAnimation);
		expressionAnimationIndex = indexAnim;
		base.animation.Blend(expressionsAnimation[expressionAnimationIndex].name, 1f, 0f);
	}

	public void sliderValueChanged(float value)
	{
		valueSlider = base.animation[currentAnimation].length * value;
	}

	public float fetchSliderValue()
	{
		return valueSlider / base.animation[currentAnimation].length;
	}
}

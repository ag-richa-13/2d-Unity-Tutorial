using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

class StoryBlocks
{
    public string Story;
    public string OptionAText;
    public string OptionBText;

    public StoryBlocks OptionABlock;           //Object
    public StoryBlocks OptionBBlock;             //Object


    // Create Constructor
    public StoryBlocks(string story, string optionAText = "", string optionBText = "", StoryBlocks optionABlock = null, StoryBlocks optionBBlock = null)
    {
        this.Story = story;
        this.OptionABlock = optionABlock;
        this.OptionBBlock = optionBBlock;
        this.OptionAText = optionAText;
        this.OptionBText = optionBText;

    }


}
public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text StoryText;
    [SerializeField] private Button OptionA, OptionB;

    StoryBlocks currentBlock;

    static StoryBlocks blockH = new StoryBlocks("Wait for game over.");
    static StoryBlocks blockG = new StoryBlocks("That key was found. Door opens. You are free.");
    static StoryBlocks blockF = new StoryBlocks("Small Stones on floor. You found key", "Do nothing", "try to unlock door", blockH, blockG);
    static StoryBlocks blockE = new StoryBlocks("Nothing in pocket", "Check Doors", "Inspect floor", blockC, blockF);
    static StoryBlocks blockD = new StoryBlocks("Tired of Screaming, having thought to escape on your Own", "Check Pockets", "Inspect floor", blockE, blockF);
    static StoryBlocks blockC = new StoryBlocks("Big wooden Door", "Do nothing", "Inspect floor", blockH, blockF);
    static StoryBlocks blockB = new StoryBlocks("Started Paninc, think alone", "Looking for door", "Sit down", blockC, blockD);
    static StoryBlocks blockA = new StoryBlocks("Wake up in Small castle", "Looking for door", "Check for others", blockC, blockB);

    private void Start()
    {
        DisplayBlock(blockA);
    }
    private void DisplayBlock(StoryBlocks block)
    {
        StoryText.text = block.Story;
        OptionA.GetComponentInChildren<TMP_Text>().text = block.OptionAText;
        OptionB.GetComponentInChildren<TMP_Text>().text = block.OptionBText;

        currentBlock = block;
    }

    public void OnButtonAClick()
    {
        DisplayBlock(currentBlock.OptionABlock);
    }

    public void OnButtonBClick()
    {
        DisplayBlock(currentBlock.OptionBBlock);
    }
}

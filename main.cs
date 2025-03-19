using TikTokLiveSharp.Client;
using System;
using TikTokLiveSharp;
using TikTokLiveUnity;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TikTokLiveSharp.Events;
using TikTokLiveSharp.Models.Protobuf.Messages;
using TikTokLiveSharp.Events.Objects;
using Text = UnityEngine.UI.Text;
using TikTokLiveSharp.Models.HTTP;

namespace TikTokLiveUnity
{
    public class TikTokManager : MonoBehaviour
    {
        private static TikTokManager instance;

        public static TikTokManager Instance
        {
            get { return instance; }
        }

        public Text input;
        public GameObject lastscreen;
        public GameObject commentPrefab;
        public GameObject likePrefab;
        public string username = "livelimited";
        private TikTokLiveManager mgr => TikTokLiveManager.Instance;

        // Define an array of 7 possible positions
        private Vector3[] possiblePositions;

        // Reference to the Text component for displaying actions
        public Text actionText; // Assign in the Inspector

        public void Click()
        {
            username = input.text;
            Debug.Log(input.text);
            DontDestroyOnLoad(gameObject);
            mgr.OnChatMessage += OnComment;
            mgr.OnLike += OnLike;
            mgr.OnGiftMessage += OnGiftMessage;
            Connect();
            Destroy(lastscreen);

            // Initialize the array of 7 possible positions
            possiblePositions = new Vector3[]
            {
                new Vector3(-0.06f, 7.28f, -2.76f),
                new Vector3(0.133f, 7.28f, -2.76f),
                new Vector3(0.2f, 7.28f, -2.76f),
                new Vector3(-0.2f, 7.28f, -2.76f),
                new Vector3(0.3f, 7.28f, -2.76f),
                new Vector3(-0.3f, 7.28f, -2.76f),
                new Vector3(0.4f, 7.28f, -2.76f)
            };
        }

        private void OnComment(TikTokLiveClient sender, Chat e)
        {
            SpawnPrefab(commentPrefab);
            SpawnPrefab(commentPrefab);
            SpawnPrefab(commentPrefab);
        }

        void OnGiftMessage(TikTokLiveClient sender, TikTokLiveSharp.Events.GiftMessage e)
        {
            {


                var gift = e.Gift;
                string giftName = gift.Name;
                long amount = e.Amount;

                // Implement the gift handling logic here


                if (giftName == "Rose") // Received a rose gift
                {
                    SpawnPrefab(commentPrefab); // AKA GIRLS CIRCLE
                    SpawnPrefab(commentPrefab);
                    SpawnPrefab(commentPrefab);
                    SpawnPrefab(commentPrefab);
                    SpawnPrefab(commentPrefab);
                    SpawnPrefab(commentPrefab);
                    SpawnPrefab(commentPrefab);
                    SpawnPrefab(commentPrefab);
                    SpawnPrefab(commentPrefab);
                    SpawnPrefab(commentPrefab);
                    Debug.Log($"Received a rose gift");
                }
                else if (giftName == "TikTok")
                {
                    SpawnPrefab(likePrefab); // AKA BOYS CIRCLE
                    SpawnPrefab(likePrefab);
                    SpawnPrefab(likePrefab);
                    SpawnPrefab(likePrefab);
                    SpawnPrefab(likePrefab);
                    SpawnPrefab(likePrefab);
                    SpawnPrefab(likePrefab);
                    SpawnPrefab(likePrefab);
                    SpawnPrefab(likePrefab);
                    SpawnPrefab(likePrefab);
                    Debug.Log($"Received a TIKTOK gift"); 
                }
                    // Calculate the number of balls to spawn based on the gift amount
                    //  int numBallsToSpawn = (int)gift.Amount * 10;
                    //    Debug.Log($"Spawning {numBallsToSpawn} balls for the rose gift");

                    // Instantiate the prefab multiple times
                    //    for (int i = 0; i < numBallsToSpawn; i++)
                    //     {
                    //    SpawnPrefab(commentPrefab);
                    //   }

                    // Update the Text component with the gift action
                    //    UpdateActionText($"Received a Rose Gift x{gift.Amount}");
                    //  }
                    //   else if (gift.Gift.Id == 5269UL) // Received a weights gift
                    //   {
                    //    Debug.Log($"Received a weights gift x{gift.Amount}");

                    // Calculate the number of balls to spawn based on the gift amount
                    //    int numBallsToSpawn = (int)gift.Amount * 10;
                    //    Debug.Log($"Spawning {numBallsToSpawn} balls for the weights gift");

                    // Instantiate the prefab multiple times
                    //    for (int i = 0; i < numBallsToSpawn; i++)
                    //    {
                    //        SpawnPrefab(likePrefab);
                    //    }

                    // Update the Text component with the gift action
                    //         UpdateActionText($"Received a Weights Gift x{gift.Amount}");
                    //}
                }
        }

            private void OnDestroy()
        {
            if (!TikTokLiveManager.Exists)
                return;
               mgr.OnChatMessage -= OnComment;
            mgr.OnLike -= OnLike;
            mgr.OnGiftMessage -= OnGiftMessage;
        }

        private void Connect()
        {
            bool connected = mgr.Connected;
            bool connecting = mgr.Connecting;
            if (connected || connecting)
                Debug.Log("Already connected or connecting");
            else mgr.ConnectToStreamAsync(username, Debug.LogException);
            Debug.Log("Connecting");
        }

        //    private void OnComment(TikTokLiveClient sender, ChatMessage comment)
        //    {
        //     string senderUsername = comment.User?.NickName ?? "Unknown";
        //     string commentText = comment.Text;
        //     Debug.Log($"COMMENT from {senderUsername}: {commentText}");

        // Spawn three prefabs for comments
        //      SpawnMultiplePrefabs(commentPrefab, 3);

        // Update the Text component with the comment action
        //    UpdateActionText($"{senderUsername} Commented");
        //   }

        private void OnLike(TikTokLiveClient sender, Like like)
        {
            string senderUsername = like.Sender?.NickName ?? "Unknown";
            Debug.Log($"{senderUsername} liked the stream.");

            SpawnPrefab(likePrefab);

            // Update the Text component with the like action
            UpdateActionText($"{senderUsername} Liked");
        }





     //   private void OnGiftMessage(TikTokLiveClient sender, TikTokGift gift)
     //   {
       //     SpawnPrefab(commentPrefab);
      //  }
        //    if (gift.Gift.Id == 5655UL) // Received a rose gift
        //    {
        //   Debug.Log($"Received a rose gift x{gift.Amount}");

        // Calculate the number of balls to spawn based on the gift amount
        //  int numBallsToSpawn = (int)gift.Amount * 10;
        //    Debug.Log($"Spawning {numBallsToSpawn} balls for the rose gift");

        // Instantiate the prefab multiple times
        //    for (int i = 0; i < numBallsToSpawn; i++)
        //     {
        //    SpawnPrefab(commentPrefab);
 //   }

    // Update the Text component with the gift action
    //    UpdateActionText($"Received a Rose Gift x{gift.Amount}");
    //  }
    //   else if (gift.Gift.Id == 5269UL) // Received a weights gift
    //   {
    //    Debug.Log($"Received a weights gift x{gift.Amount}");

    // Calculate the number of balls to spawn based on the gift amount
    //    int numBallsToSpawn = (int)gift.Amount * 10;
    //    Debug.Log($"Spawning {numBallsToSpawn} balls for the weights gift");

    // Instantiate the prefab multiple times
    //    for (int i = 0; i < numBallsToSpawn; i++)
    //    {
    //        SpawnPrefab(likePrefab);
    //    }

    // Update the Text component with the gift action
    //         UpdateActionText($"Received a Weights Gift x{gift.Amount}");
    //}
    //   }

    private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void SpawnPrefab(GameObject prefab)
        {
            // Randomly choose one of the positions from the array
            Vector3 position = possiblePositions[UnityEngine.Random.Range(0, possiblePositions.Length)];

            Quaternion rotation = Quaternion.Euler(90f, 0f, 0f);
            GameObject obj = Instantiate(prefab, position, rotation);

            // Set the layer to "Balls"
            obj.layer = LayerMask.NameToLayer("Balls");
        }

        private void UpdateActionText(string action)
        {
            // Update the Text component with the action
            actionText.text = action;
        }
    }
}
